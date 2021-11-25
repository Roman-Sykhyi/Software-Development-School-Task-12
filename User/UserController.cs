using System;
using System.Collections.Generic;

namespace Завдання_12.User
{
    public class UserController : IClientTypeChanger
    {
        public IReadOnlyList<User> Users => _users.AsReadOnly();
        private List<User> _users;

        public void ChangeClientType(Guid clientId, ClientType clientType)
        {
            User user = _users.Find((User u) => u.Id == clientId);

            if(user is Client)
            {
                Client client = user as Client;
                client.SetType(clientType);
            }
        }
    }
}