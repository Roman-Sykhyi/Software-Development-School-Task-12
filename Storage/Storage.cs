using System.Collections.Generic;

namespace Завдання_12.Storage
{
    public class Storage
    {
        public List<(Product, int)> products;

        public Storage()
        {
            products = new List<(Product, int)>();
        }
    }
}