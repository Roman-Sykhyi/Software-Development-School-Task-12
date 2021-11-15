using System;
using System.Collections.Generic;

namespace Завдання_12.User
{
    public class UserController : IClientTypeChanger
    {
        public IReadOnlyList<User> Users => _users.AsReadOnly();
        private List<User> _users;

        public void ChangeClientType(Client client, ClientType clientType)
        {
            throw new NotImplementedException();
        }
    }
}