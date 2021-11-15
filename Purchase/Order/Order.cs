using System;
using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase.Order
{
    public class Order
    {
        public Guid Id { get; private set; }

        private List<(Product, int)> _purchases;
        private Client _client;
        private bool delivery;
    }
}