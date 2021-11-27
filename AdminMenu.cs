using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    public class AdminMenu
    {
        private static string name;
        private static float price;
        private static float weight;
        private static int expirationDate; // in days
        private static DateTime manufactureDate;

        public static void ShowAdministratorMenu()
        {
            Administrator administrator = Program.currentUser as Administrator;

            int choice;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nВиберіть дію:");
                    Console.WriteLine("1 - Переглянути товари");
                    Console.WriteLine("2 - Змінити статус клієнта");
                    Console.WriteLine("3 - Додати товар на склад");
                    Console.WriteLine("4 - Видалити товар зі складу");
                    Console.WriteLine("5 - Вийти");
                } while ((!int.TryParse(Console.ReadLine(), out choice)));

                switch (choice)
                {
                    case 1:
                        Program.ViewProducts(Program.storageController.GetProducts());
                        break;
                    case 2:
                        AdminChangeClientType(administrator);
                        break;
                    case 3:
                        AdminAddProductToStorage(administrator);
                        break;
                    case 4:
                        AdminRemoveProductFromStorage(administrator);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void AdminRemoveProductFromStorage(Administrator administrator)
        {
            Console.WriteLine("Видалення товару зі складу.");

            (Product, int) product;

            while(true)
            {
                Console.Write("Введіть назву товару: ");
                string name = Console.ReadLine();

                product = Program.storageController.GetProduct(name);

                if (name.Equals("exit"))
                    return;

                if (product.Item1 == null)
                    Console.WriteLine("Товару з такою назвою на складі не знайдено");
                else
                    break;
            }

            int amount = 0;

            do
            {
                Console.Write("Введіть кількість товару: ");
            } while (!(int.TryParse(Console.ReadLine(), out amount)) || amount <= 0);

            administrator.storageAdministrator.RemoveProduct(product.Item1, amount);
        }

        private static void AdminAddProductToStorage(Administrator administrator)
        {
            Console.WriteLine("Додавання товару на склад.");
            Product product = GetNewProductFromConsole();

            int amount;
            do
            {
                Console.Write("Введіть кількість: ");
            } while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0);

            administrator.storageAdministrator.AddProduct(product, amount);
        }

        private static void AdminChangeClientType(Administrator administrator)
        {
            Console.WriteLine("Зміна типу клієнта");

            Console.Write("Введіть логін клієнта: ");
            string login = Console.ReadLine();

            ClientType type;
            string typeStr;
            do
            {
                Console.Write("Виберіть тип (0 - звичайний клієнт, 1 - новий клієнт, 2 - ВІП клієнт): ");
                typeStr = Console.ReadLine();
            } while (!Enum.TryParse(typeStr, out type));

            administrator.clientTypeChanger.ChangeClientType(login, type);
        }

        private static Product GetNewProductFromConsole()
        {
            Console.Clear();
            Console.WriteLine("Виберіть тип продукту");
            Console.WriteLine("P - звичайний продукт");
            Console.WriteLine("M - м'ясний продукт");
            Console.WriteLine("D - молочний продукт");

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    return GetProductFromConsole();
                case ConsoleKey.M:
                    return GetMeatProductFromConsole();
                case ConsoleKey.D:
                    return GetDairyProductFromConsole();
                default:
                    return null;
            }
        }

        private static Product GetProductFromConsole()
        {
            GetDefaultProductAtributesFromConsole();
            return new Product(name, price, weight, expirationDate, manufactureDate);
        }

        private static DairyProduct GetDairyProductFromConsole()
        {
            return GetProductFromConsole() as DairyProduct;
        }

        private static Meat GetMeatProductFromConsole()
        {
            Console.Clear();

            Console.Write("Виберіть вид м'яса (баранина - 1, телятина - 2, свинина - 3, курятина - 4): ");
            MeatType meatType = Enum.Parse<MeatType>(Console.ReadLine());

            Console.Write("Виберіть сорт м'яса (вищий - 1, перший - 2, другий - 3): ");
            MeatGrade meatGrade = Enum.Parse<MeatGrade>(Console.ReadLine());

            GetDefaultProductAtributesFromConsole();

            return new Meat(name, price, weight, meatGrade, meatType, expirationDate, manufactureDate);
        }

        private static void GetDefaultProductAtributesFromConsole()
        {
            Console.Clear();

            Console.Write("Введіть назву товару: ");
            name = Console.ReadLine();

            Console.Write("Введіть ціну товару (xx,xx): ");
            if (!float.TryParse(Console.ReadLine(), out price))
                throw new ArgumentException("Помилка введення ціни товару", nameof(price));

            Console.Write("Введіть вагу товару (xx,xx): ");
            if (!float.TryParse(Console.ReadLine(), out weight))
                throw new ArgumentException("Помилка введення ваги товару", nameof(weight));

            Console.Write("Введіть термін придатності (к-сть днів): ");
            if (!int.TryParse(Console.ReadLine(), out expirationDate))
                throw new ArgumentException("Помилка введення терміну придатності товару", nameof(expirationDate));

            Console.Write("Введіть дату виготовлення (дд.мм.рррр): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out manufactureDate))
                throw new ArgumentException("Помилка введення дати виготовлення товару", nameof(manufactureDate));
        }
    }
}