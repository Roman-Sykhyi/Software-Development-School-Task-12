using Завдання_12.UserClasses;

namespace Завдання_12.Purchase.PromoAction
{
    public interface IPromoActionCreator
    {
        public void CreatePromoAction(Product product, ClientType clientType, double discount);
    }
}