using System;
using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase.PromoAction
{
    public class PromoActionsController : IPromoActionCreator, IPriceCalculator
    {
        public IReadOnlyList<PromoAction> PromoActions => _promoActions.AsReadOnly();
        private List<PromoAction> _promoActions = new List<PromoAction>();

        public void CreatePromoAction(Product product, ClientType clientType, double discount)
        {
            _promoActions.Add(new PromoAction(product, clientType, discount));
        }

        public double GetTotalPrice(IReadOnlyList<(Product, int)> products, ClientType clientType)
        {
            double totalPrice = 0;

            foreach((Product, int) product in products)
            {
                PromoAction promoAction = _promoActions.Find((PromoAction promo) => promo.Product.Name.Equals(product.Item1.Name) && promo.ClientType == clientType);
                double productPrice = product.Item1.Price;

                if (promoAction != null)
                {
                    productPrice -= promoAction.Discount;
                }

                totalPrice += productPrice * product.Item2;
            }

            return totalPrice;
        }
    }
}