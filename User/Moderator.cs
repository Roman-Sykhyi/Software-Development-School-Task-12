using System;
using Завдання_12.Purchase.Order;
using Завдання_12.Purchase.PromoAction;

namespace Завдання_12.UserClasses
{
    public class Moderator : User
    {
        public IOrderModerator orderModerator;
        public IPromoActionCreator promoActionCreator;

        public Moderator(Guid id, string name, string login, string password, IOrderModerator orderModerator, IPromoActionCreator promoActionCreator)
            : base(id, name, login, password)
        {
            this.orderModerator = orderModerator ?? throw new ArgumentNullException(nameof(orderModerator));
            this.promoActionCreator = promoActionCreator ?? throw new ArgumentNullException(nameof(promoActionCreator));
        }
    }
}