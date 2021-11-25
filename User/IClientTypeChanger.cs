using System;

namespace Завдання_12.User
{
    public interface IClientTypeChanger
    {
        public void ChangeClientType(Guid clientId, ClientType clientType);
    }
}