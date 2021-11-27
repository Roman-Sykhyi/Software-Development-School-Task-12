using System;
using System.Collections.Generic;

namespace Завдання_12.Purchase.Order
{
    public class Order
    {
        public Guid Id { get; private set; }

        private IReadOnlyList<(Product, int)> _purchases;
        private string _clientLogin;
        private double _totalPrice;
        private bool _delivery;

        public Order(IReadOnlyList<(Product, int)> purchases, string clientLogin, bool delivery, double totalPrice)
        {
            Id = Guid.NewGuid();
            _purchases = purchases ?? throw new ArgumentNullException(nameof(purchases));
            _clientLogin = clientLogin;
            _totalPrice = totalPrice;
            _delivery = delivery;
        }

        public override string ToString()
        {
            string result = "Ідентифікатор замовлення: " + Id;
            result += ". Замовник: " + _clientLogin;
            result += ". Сума замовлення: " + _totalPrice;
            result += ". Доставка додому: ";

            if (_delivery)
                result += "так.";
            else
                result += "ні.";

            result += "\nСписок товарів:\n";

            foreach((Product, int) product in _purchases)
            {
                Console.WriteLine(product.Item1.ToString() + " К-сть: " + product.Item2);
            }

            return result;
        }
    }
}