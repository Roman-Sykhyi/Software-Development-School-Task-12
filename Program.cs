using System;
using System.Collections.Generic;
using Завдання_12.Purchase.Order;
using Завдання_12.Purchase.PromoAction;
using Завдання_12.StorageClasses;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    class Program
    {
        public static Storage storage = new Storage();

        public static UserController userController = new UserController();
        public static StorageController storageController = new StorageController(storage);
        public static OrdersController ordersController = new OrdersController();
        public static PromoActionsController promoActionsController = new PromoActionsController();

        public static User currentUser;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            userController.AddAdministrator(Guid.NewGuid(), "ADMIN", "admin", "admin", storageController, userController);
            userController.AddModerator(Guid.NewGuid(), "MODERATOR", "mod", "mod", ordersController, promoActionsController);

            АuthenticationFunctions.UserEnterProgram();

            if(currentUser is Client)
            {
                ClientMenu.ShowClientMenu();
            }
            else if (currentUser is Moderator)
            {
                ShowModeratorMenu();
            }
            else if (currentUser is Administrator)
            {
                AdminMenu.ShowAdministratorMenu();
            }

            Console.ReadKey();
        }

        private static void ShowModeratorMenu()
        {
            Moderator moderator = currentUser as Moderator;


        }

        public static void ViewProducts(IReadOnlyList<(Product, int)> products)
        {
            foreach((Product, int) item in products)
            {
                Console.WriteLine(item.Item1 + ". К-сть: " + item.Item2);
            }
        }
    }
}