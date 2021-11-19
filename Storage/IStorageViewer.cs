using System.Collections.Generic;

namespace Завдання_12.StorageClasses
{
    public interface IStorageViewer
    {
        public IReadOnlyList<(Product, int)> GetProducts();
    }
}