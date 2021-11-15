using Завдання_12.Storage;

namespace Завдання_12.User
{
    public class Administrator : User
    {
        public StorageController storageController;
        public IClientTypeChanger clientTypeChanger;
    }
}