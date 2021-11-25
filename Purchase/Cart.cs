using System;
using System.Collections.Generic;
using Завдання_12.Purchase.Order;
using Завдання_12.User;

namespace Завдання_12.Purchase
{
    public class Cart
    {
        public IReadOnlyList<(Product, int)> Purchases => _purchases.AsReadOnly();
        private List<(Product, int)> _purchases = new List<(Product, int)>();

        public void AddPurchase(Product product, int amount)
        {
            var productIndex = _purchases.FindIndex(0, _purchases.Count, ((Product, int) p) => p.Item1.Name.Equals(product.Name));

            if (productIndex != -1)
            {
                var prod = (product, _purchases[productIndex].Item2 + amount);
                _purchases[productIndex] = prod;
            }
            else
            {
                _purchases.Add((product, amount));
            }
        }

        public void RemovePurchase(Product product, int amount)
        {
            int productIndex = _purchases.FindIndex(0, _purchases.Count, ((Product, int) p) => p.Item1.Name.Equals(product.Name));

            if (productIndex != -1)
            {
                _purchases[productIndex] = (product, _purchases[productIndex].Item2 - amount);

                if (_purchases[productIndex].Item2 < 1)
                    _purchases.RemoveAt(productIndex);
            }
        }

        public void Clear()
        {
            _purchases.Clear();
        }
    }
}