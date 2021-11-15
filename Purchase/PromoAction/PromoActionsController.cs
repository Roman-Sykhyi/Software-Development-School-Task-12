using System;
using System.Collections.Generic;
using Завдання_12.User;

namespace Завдання_12.Purchase.PromoAction
{
    public class PromoActionsController : IPromoActionCreator, IPriceCalculator
    {
        public IReadOnlyList<PromoAction> PromoActions => _promoActions.AsReadOnly();
        private List<PromoAction> _promoActions;

        public void CreatePromoAction(Product product, ClientType clientType, double discount)
        {
            throw new NotImplementedException();
        }

        public double GetTotalPrice(List<(Product, int)> products, ClientType clientType)
        {
            throw new NotImplementedException();
        }
    }
}