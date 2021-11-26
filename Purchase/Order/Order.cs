using System;
using System.Collections.Generic;

namespace Завдання_12.Purchase.Order
{
    public class Order
    {
        public Guid Id { get; private set; }

        private IReadOnlyList<(Product, int)> _purchases;
        private Guid _clientId;
        private double _totalPrice;
        private bool _delivery;

        public Order(IReadOnlyList<(Product, int)> purchases, Guid clientId, bool delivery, double totalPrice)
        {
            Id = Guid.NewGuid();
            _purchases = purchases ?? throw new ArgumentNullException(nameof(purchases));
            _clientId = clientId;
            _totalPrice = totalPrice;
            _delivery = delivery;
        }
    }
}