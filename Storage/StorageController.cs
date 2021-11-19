using System;
using System.Collections.Generic;

namespace Завдання_12.StorageClasses
{
    public class StorageController : IStorageViewer
    {
        private Storage _storage;

        public StorageController(Storage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void AddProduct(Product newProduct, int amount)
        {
            var productIndex = _storage.products.FindIndex(0, _storage.products.Count, ((Product, int) p) => p.Item1.Name.Equals(newProduct.Name));

            if (productIndex != -1)
            {
                var product = (newProduct, _storage.products[productIndex].Item2 + amount);
                _storage.products[productIndex] = product;
            }
            else
            {
                _storage.products.Add((newProduct, amount));
            }
        }

        public void RemoveProduct(Product product, int amount)
        {
            int productIndex = _storage.products.FindIndex(0, _storage.products.Count, ((Product, int) p) => p.Item1.Name.Equals(product.Name));

            if (productIndex != -1)
            {
                _storage.products[productIndex] = (product, _storage.products[productIndex].Item2 - amount);

                if (_storage.products[productIndex].Item2 < 1)
                    _storage.products.RemoveAt(productIndex);
            }
        }

        public void RemoveProduct(string name, int amount)
        {
            int productIndex = _storage.products.FindIndex(0, _storage.products.Count, ((Product, int) p) => p.Item1.Name.Equals(name));

            if (productIndex != -1)
            {
                _storage.products[productIndex] = (_storage.products[productIndex].Item1, _storage.products[productIndex].Item2 - amount);

                if (_storage.products[productIndex].Item2 < 1)
                    _storage.products.RemoveAt(productIndex);
            }
        }

        public (Product, int) GetProduct(string name)
        {
            return _storage.products.Find(((Product, int) p) => p.Item1.Name.Equals(name));
        }

        public IReadOnlyList<(Product, int)> GetProducts()
        {
            return _storage.products.AsReadOnly();
        }
    }
}