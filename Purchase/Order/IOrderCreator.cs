using System;
using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase.Order
{
    public interface IOrderCreator
    {
        public void CreateOrder(IReadOnlyList<(Product, int)> purchases, Guid clientId, ClientType clientType, bool delivery);
    }
}