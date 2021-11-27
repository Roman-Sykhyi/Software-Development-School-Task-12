using System;
using System.Collections.Generic;
using System.Text;
using Завдання_12.Purchase.Order;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    public class ModeratorMenu
    {
        public static void ShowModeratorMenu()
        {
            Moderator moderator = Program.currentUser as Moderator;
            
            int choice;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nВиберіть дію:");
                    Console.WriteLine("1 - Переглянути товари");
                    Console.WriteLine("2 - Переглянути замовлення");
                    Console.WriteLine("3 - Видалити замовлення");
                    Console.WriteLine("4 - Створити нову акцію");
                    Console.WriteLine("5 - Вийти");
                } while ((!int.TryParse(Console.ReadLine(), out choice)));

                switch (choice)
                {
                    case 1:
                        Program.ViewProducts(Program.storageController.GetProducts());
                        break;
                    case 2:
                        ModeratorViewOrders(moderator);
                        break;
                    case 3:
                        ModeratorDeleteOrder(moderator);
                        break;
                    case 4:
                        ModeratorCreatePromoAction(moderator);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void ModeratorCreatePromoAction(Moderator moderator)
        {
            Console.WriteLine("Створення нової знижки");

            (Product, int) product;

            while (true)
            {
                Console.Write("Введіть назву товару (введіть exit для виходу в меню): ");
                string name = Console.ReadLine();

                if (name.Equals("exit"))
                    return;

                product = Program.storageController.GetProduct(name);

                if (product.Item1 != null)
                    break;
            }

            ClientType type;
            string typeStr;
            do
            {
                Console.Write("Виберіть тип (0 - звичайний клієнт, 1 - новий клієнт, 2 - ВІП клієнт): ");
                typeStr = Console.ReadLine();
            } while (!Enum.TryParse(typeStr, out type));

            double discount;

            do
            {
                Console.Write("Введіть розмір знижки: ");
            } while (!double.TryParse(Console.ReadLine(), out discount) || discount <= 0);

            moderator.promoActionCreator.CreatePromoAction(product.Item1, type, discount);
        }

        private static void ModeratorDeleteOrder(Moderator moderator)
        {
            Console.WriteLine("Введіть ідентифікатор замовлення");
            Guid orderId = Guid.Parse(Console.ReadLine());
            Order order = moderator.orderModerator.GetOrder(orderId);
            moderator.orderModerator.DeleteOrder(order);
        }

        private static void ModeratorViewOrders(Moderator moderator)
        {
            Console.WriteLine("Перегляд замовлень");

            foreach(Order order in Program.ordersController.Orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}
