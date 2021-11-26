using System;
using System.Collections.Generic;
using Завдання_12.Purchase.Order;
using Завдання_12.Purchase.PromoAction;
using Завдання_12.StorageClasses;

namespace Завдання_12.UserClasses
{
    public class UserController : IClientTypeChanger
    {
        public IReadOnlyList<User> Users => _users.AsReadOnly();
        private List<User> _users = new List<User>();

        public User GetUser(string login , string password)
        {
            User user = _users.Find((User u) => u.Login.Equals(login));

            if(!user.Password.Equals(password))
            {
                return null;
            }

            return user;
        }

        public void RegisterNewClient(Guid id, string name, string login, string password, string address, IStorageViewer storageViewer, IOrderCreator orderCreator)
        {
            Client client = new Client(id, name, login, password, address, storageViewer, orderCreator);
            _users.Add(client);
        }

        public void AddAdministrator(Guid id, string name, string login, string password, IStorageAdministrator storageAdministrator, IClientTypeChanger clientTypeChanger)
        {
            Administrator administrator = new Administrator(id, name, login, password, storageAdministrator, clientTypeChanger);
            _users.Add(administrator);
        }

        public void AddModerator(Guid id, string name, string login, string password, IOrderModerator orderModerator, IPromoActionCreator promoActionCreator)
        {
            Moderator moderator = new Moderator(id, name, login, password, orderModerator, promoActionCreator);
            _users.Add(moderator);
        }

        public void ChangeClientType(string login, ClientType clientType)
        {
            User user = _users.Find((User u) => u.Login.Equals(login));

            if(user is Client)
            {
                Client client = user as Client;
                client.SetType(clientType);
            }
        }
    }
}