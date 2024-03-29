﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public interface IShoppingItemService
    {
        ShoppingItem AddShoppingItem(ShoppingItem shoppingItem);
        List<ShoppingItem> RetrieveAllShoppingItems();
        ShoppingItem RetrieveShoppingItemById(int id);
        ShoppingItem ModifyShoppingItem(ShoppingItem shoppingItem);
        ShoppingItem RemoveShoppingItem(ShoppingItem shoppingItem);
    }
}