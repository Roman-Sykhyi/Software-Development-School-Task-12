using System;
using System.Collections.Generic;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    public class ClientMenu
    {
        public static void ShowClientMenu()
        {
            Client client = Program.currentUser as Client;

            int choice;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nВиберіть дію:");
                    Console.WriteLine("1 - Переглянути товари");
                    Console.WriteLine("2 - Переглянути корзину");
                    Console.WriteLine("3 - Додати товар в корзину");
                    Console.WriteLine("4 - Видалити товар з корзини");
                    Console.WriteLine("5 - Підтвердити замовлення");
                    Console.WriteLine("6 - Вийти");
                } while ((!int.TryParse(Console.ReadLine(), out choice)));

                switch (choice)
                {
                    case 1:
                        Program.ViewProducts(client.ShowStorage());
                        break;
                    case 2:
                        Program.ViewProducts(client.Cart.Purchases);
                        break;
                    case 3:
                        ClientAddProductToCart(client);
                        break;
                    case 4:
                        ClientRemoveProductFromCart(client);
                        break;
                    case 5:
                        ClientConfirmOrder(client);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void ClientRemoveProductFromCart(Client client)
        {
            Console.WriteLine("Видалення товару з корзини");
            (Product, int) product;
            while (true)
            {
                Console.Write("Введіть назву товару (введіть exit, щоб повернутись в меню): ");
                string name = Console.ReadLine();

                List<(Product, int)> products = new List<(Product, int)>(client.Cart.Purchases);

                product = products.Find(((Product, int) p) => p.Item1.Name.Equals(name));

                if (name.Equals("exit"))
                    return;

                if (product.Item1 == null)
                    Console.WriteLine("Товару з такою назвою в корзині не знайдено");
                else
                    break;
            }

            int amount = 0;

            do
            {
                Console.Write("Введіть кількість товару: ");
            } while (!(int.TryParse(Console.ReadLine(), out amount)) || amount <= 0);

            client.Cart.RemovePurchase(product.Item1, amount);
        }

        private static void ClientAddProductToCart(Client client)
        {
            Console.WriteLine("Додавання товару в корзину");
            (Product, int) product;
            while (true)
            {
                Console.Write("Введіть назву товару (введіть exit, щоб повернутись в меню): ");
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

            client.Cart.AddPurchase(product.Item1, amount);
        }

        private static void ClientConfirmOrder(Client client)
        {
            if (client.Cart.Purchases.Count == 0)
            {
                Console.WriteLine("Корзина пуста. Спочатку виберіть товар.");
                return;
            }

            Console.WriteLine("Підтвердження замовлення");
            int choice;
            do
            {
                Console.Write("\nВиберіть тип доставки (1 - доставка додому, 2 - самовивіз): ");
            } while ((!int.TryParse(Console.ReadLine(), out choice)) || (choice != 1 && choice != 2));

            if (choice == 1)
            {
                client.ConfirmOrder(true);
                Console.WriteLine("Замовлення підтверджено. Товар буде доставлено вам додому.");
            }
            else
            {
                client.ConfirmOrder(false);
                Console.WriteLine("Замовлення підтверджено. Твоар відправлено на пошту.");
            }
        }
    }
}