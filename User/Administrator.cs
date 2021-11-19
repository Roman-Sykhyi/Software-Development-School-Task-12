using Завдання_12.StorageClasses;

namespace Завдання_12.User
{
    public class Administrator : User
    {
        public StorageController storageController;
        public IClientTypeChanger clientTypeChanger;
    }
}