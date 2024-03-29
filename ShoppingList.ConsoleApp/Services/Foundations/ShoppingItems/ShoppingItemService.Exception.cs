﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using Xeptions;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemService
    {
        private delegate ShoppingItem ReturningShoppingItemFunction();
        private delegate List<ShoppingItem> ReturningShoppingItemsFunction();

        private ShoppingItem TryCatch(ReturningShoppingItemFunction returningShoppingItemFunction)
        {
            try
            {
                return returningShoppingItemFunction();
            }
            catch (NullShoppingItemException nullShoppingItemException)
            {
                throw CreateAndLogValidationException(nullShoppingItemException);
            }
            catch (InvalidShoppingItemException invalidShoppingItemException)
            {
                throw CreateAndLogValidationException(invalidShoppingItemException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                var nullArgumentShoppingItemException =
                    new NullArgumentShoppingItemException(argumentNullException);

                throw CreateAndLogDependencyValidationException(
                    nullArgumentShoppingItemException);
            }
            catch (Exception exception)
            {
                var failedShoppingItemServiceException =
                    new FailedShoppingItemServiceException(exception);

                throw CreateAndLogServiceException(failedShoppingItemServiceException);
            }
        }

        private List<ShoppingItem> TryCatch(ReturningShoppingItemsFunction returningShoppingItemsFunction)
        {
            try
            {
                return returningShoppingItemsFunction();
            }
            catch (Exception exception)
            {
                var failedShoppingItemServiceException =
                    new FailedShoppingItemServiceException(exception);

                throw CreateAndLogServiceException(
                    failedShoppingItemServiceException);
            }
        }

        private ShoppingItemValidationException CreateAndLogValidationException(Xeption exception)
        {
            var shoppingItemValidationException = new ShoppingItemValidationException(exception);
            this.loggingBroker.LogError(shoppingItemValidationException);

            return shoppingItemValidationException;
        }

        private ShoppingItemDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var shoppingItemDependencyValidationException = new ShoppingItemDependencyValidationException(exception);
            this.loggingBroker.LogError(shoppingItemDependencyValidationException);

            return shoppingItemDependencyValidationException;
        }

        private ShoppingItemServiceException CreateAndLogServiceException(Xeption exception)
        {
            var shoppingItemServiceException = new ShoppingItemServiceException(exception);
            this.loggingBroker.LogError(shoppingItemServiceException);

            return shoppingItemServiceException;
        }
    }
}