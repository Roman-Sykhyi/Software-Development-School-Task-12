using System.Collections.Generic;
using Завдання_12.UserClasses;

namespace Завдання_12.Purchase
{
    public interface IPriceCalculator
    {
        public double GetTotalPrice(IReadOnlyList<(Product, int)> purchases, ClientType clientType);
    }
}