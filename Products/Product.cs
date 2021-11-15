using System;

namespace Завдання_12
{
    public class Product
    {
        public string Name { get; private set; }
        public float Price { get; private set; }
        public float Weight { get; private set; }

        public int ExpirationDate { get; private set; } // in days
        public DateTime ManufactureDate { get; private set; }

        public Product(string name, float price, float weight, int expirationDate, DateTime manufactureDate)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Назва товару не може бути пустою або null", nameof(name));

            if(price <= 0)
                throw new ArgumentException("Ціна товару не може бути меншою або рівною нулю", nameof(price));

            if(weight <= 0)
                throw new ArgumentException("Вага товару не може бути меншою або рівною нулю", nameof(price));

            if(expirationDate <= 0)
                throw new ArgumentException("Термін придатності не може бути меншим або рівним нулю", nameof(expirationDate));

            if (manufactureDate > DateTime.Now)
                throw new ArgumentException("Помилка задання дати виготовлення продукту", nameof(manufactureDate));

            Name = name;
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
            ManufactureDate = manufactureDate;
        }

        public virtual void RaisePrice(int percent)
        {
            Price *= (1 + (percent / 100));
        }

        public override string ToString()
        {
            return "Назва: " + Name + ". Ціна: " + Price + ". Вага: " + Weight + ". Термін придатності: " + ExpirationDate + " днів. Дата виготовлення: " + ManufactureDate.ToShortDateString();
        }
    }
}