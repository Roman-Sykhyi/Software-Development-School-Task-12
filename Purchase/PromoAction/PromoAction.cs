using System;
using Завдання_12.UserClasses;

namespace Завдання_12.Purchase.PromoAction
{
    public class PromoAction
    {
        public Product Product { get; private set; }
        public ClientType ClientType { get; private set; }
        public double Discount { get; private set; }

        public PromoAction(Product product, ClientType clientType, double discount)
        {
            if (discount <= 0)
                throw new ArgumentException("Discount cannot be less than 0", nameof(discount));

            Product = product ?? throw new ArgumentNullException(nameof(product));
            ClientType = clientType;
            Discount = discount;
        }
    }
}