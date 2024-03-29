﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ShoppingList.ConsoleApp.Brokers.Loggings;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems;

namespace ShoppingList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var shoppingItemService = new ShoppingItemService(storageBroker, loggingBroker);

            var inputShoppingItem = new ShoppingItem
            {
                Id = 24,
                Name = "Rice",
                Quantity = 2
            };

            shoppingItemService.AddShoppingItem(inputShoppingItem);

            inputShoppingItem = new ShoppingItem
            {
                Id = 25,
                Name = "Vegetable",
                Quantity = 6
            };

            shoppingItemService.AddShoppingItem(inputShoppingItem);
            List<ShoppingItem> storedShoppingItems = shoppingItemService.RetrieveAllShoppingItems();
            ShoppingItem returningShoppingItem = shoppingItemService.RetrieveShoppingItemById(24);

            inputShoppingItem = new ShoppingItem
            {
                Id = 23,
                Name = "New Shopping Item Bread",
                Quantity = 4
            };

            ShoppingItem modifiedShoppingItem = shoppingItemService.ModifyShoppingItem(inputShoppingItem);

            inputShoppingItem = new ShoppingItem
            {
                Id = 0,
                Name = "Record to be deleted",
                Quantity = 1
            };

            ShoppingItem deletedShoppingItem = shoppingItemService.RemoveShoppingItem(inputShoppingItem);
        }
    }
}