using Завдання_12.Purchase;
using Завдання_12.Storage;

namespace Завдання_12.User
{
    public class Client : User
    {
        public ClientType Type { get; private set; }

        public string Address { get; private set; }

        private Cart _cart;

        private IStorageViewer _storageViewer;
    }
}