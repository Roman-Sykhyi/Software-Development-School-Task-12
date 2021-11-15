using System;
using System.Collections.Generic;
using Завдання_12.Purchase.Order;

namespace Завдання_12.Purchase
{
    public class Cart
    {
        private List<(Product, int)> _purchases;

        private IOrderCreator _orderCreator;

        private IPriceCalculator _priceCalculator;

        public void AddPurchase(Product product, int amount)
        {
            throw new NotImplementedException();
        }

        public void RemovePurchase(Product product, int amount)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ConfirmOrder()
        {
            throw new NotImplementedException();
        }
    }
}