using System;
using System.Collections.Generic;

namespace Завдання_12.Purchase.Order
{
    public class OrdersController : IOrderModerator, IOrderCreator
    {
        public IReadOnlyList<Order> Orders => _orders.AsReadOnly();
        private List<Order> _orders;

        public Order GetOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}