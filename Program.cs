using System;
using Завдання_12.StorageClasses;

namespace Завдання_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            StorageController storageController = new StorageController(storage);

            Product product1 = new Product("bread", 12, 12, 1, DateTime.Now);

            storageController.AddProduct(product1, 3);
            storageController.AddProduct(product1, 2);
            storageController.RemoveProduct("bread", 1);
        }
    }
}