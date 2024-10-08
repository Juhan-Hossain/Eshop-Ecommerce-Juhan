﻿using Basket.API.Models;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();


        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice => Items.Sum(x => x.Price* x.Quantity);
        public ShoppingCart()
        {
        }
    }
}
