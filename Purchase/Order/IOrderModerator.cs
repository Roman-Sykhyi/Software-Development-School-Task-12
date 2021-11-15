using System;

namespace Завдання_12.Purchase.Order
{
    public interface IOrderModerator
    {
        public Order GetOrder(Guid orderId);
        public void DeleteOrder(Order order);
    }
}