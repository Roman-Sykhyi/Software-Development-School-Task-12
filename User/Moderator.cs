using Завдання_12.Purchase.Order;
using Завдання_12.Purchase.PromoAction;

namespace Завдання_12.User
{
    public class Moderator : User
    {
        public IOrderModerator orderModerator;
        public IPromoActionCreator promoActionCreator;
    }
}