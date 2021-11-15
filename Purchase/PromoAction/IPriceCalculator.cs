using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase
{
    interface IPriceCalculator
    {
        public double GetTotalPrice(List<(Product, int)> purchases, ClientType clientType);
    }
}