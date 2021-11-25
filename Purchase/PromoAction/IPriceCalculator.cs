using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase
{
    public interface IPriceCalculator
    {
        public double GetTotalPrice(IReadOnlyList<(Product, int)> purchases, ClientType clientType);
    }
}