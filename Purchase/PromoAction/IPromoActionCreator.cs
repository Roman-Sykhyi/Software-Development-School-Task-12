using Завдання_12.User;

namespace Завдання_12.Purchase.PromoAction
{
    public interface IPromoActionCreator
    {
        public void CreatePromoAction(Product product, ClientType clientType, double discount);
    }
}