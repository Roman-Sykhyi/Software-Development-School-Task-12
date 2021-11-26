using System;
using Завдання_12.StorageClasses;

namespace Завдання_12.UserClasses
{
    public class Administrator : User
    {
        public IStorageAdministrator storageAdministrator;
        public IClientTypeChanger clientTypeChanger;

        public Administrator(Guid id, string name, string login, string password, IStorageAdministrator storageAdministrator, IClientTypeChanger clientTypeChanger) 
            : base (id, name, login, password)
        {
            this.storageAdministrator = storageAdministrator ?? throw new ArgumentNullException(nameof(storageAdministrator));
            this.clientTypeChanger = clientTypeChanger ?? throw new ArgumentNullException(nameof(clientTypeChanger));
        }
    }
}