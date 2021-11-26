namespace Завдання_12.StorageClasses
{
    public interface IStorageAdministrator
    {
        public void AddProduct(Product newProduct, int amount);
        public void RemoveProduct(Product product, int amount);
        public void RemoveProduct(string name, int amount);
    }
}
