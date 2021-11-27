using System;
using System.Collections.Generic;
using Завдання_12.UserClasses;

namespace Завдання_12.Purchase.Order
{
    public class OrdersController : IOrderModerator, IOrderCreator
    {
        public IReadOnlyList<Order> Orders => _orders.AsReadOnly();
        private List<Order> _orders = new List<Order>();

        private IPriceCalculator _priceCalculator;

        public OrdersController(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator ?? throw new ArgumentNullException(nameof(priceCalculator));
        }

        public Order GetOrder(Guid orderId)
        {
            return _orders.Find((Order o) => o.Id == orderId);
        }

        public void CreateOrder(IReadOnlyList<(Product, int)> purchases, string login, ClientType clientType, bool delivery)
        {
            Order order = new Order(purchases, login, delivery, _priceCalculator.GetTotalPrice(purchases, clientType));
            _orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            _orders.Remove(order);
        }
    }
}