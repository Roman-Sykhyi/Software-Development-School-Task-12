using System;
using System.Collections.Generic;
using Завдання_12.UserClasses;

namespace Завдання_12.Purchase.Order
{
    public interface IOrderCreator
    {
        public void CreateOrder(IReadOnlyList<(Product, int)> purchases, string clientLogin, ClientType clientType, bool delivery);
    }
}