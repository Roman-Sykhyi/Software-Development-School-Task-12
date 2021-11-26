using System;
using Завдання_12.Purchase.Order;
using Завдання_12.Purchase.PromoAction;
using Завдання_12.StorageClasses;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    class Program
    {
        static Storage storage = new Storage();

        static UserController userController = new UserController();
        static StorageController storageController = new StorageController(storage);
        static OrdersController ordersController = new OrdersController();
        static PromoActionsController promoActionsController = new PromoActionsController();

        static User currentUser;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            userController.AddAdministrator(Guid.NewGuid(), "ADMIN", "admin", "admin", storageController, userController);
            userController.AddModerator(Guid.NewGuid(), "MODERATOR", "mod", "mod", ordersController, promoActionsController);

            UserEnterProgram();

            if(currentUser is Client)
            {
                ShowClientMenu();
            }
            else if (currentUser is Moderator)
            {
                ShowModeratorMenu();
            }
            else if (currentUser is Administrator)
            {
                ShowAdministratorMenu();
            }

            Console.ReadKey();
        }

        private static void ShowAdministratorMenu()
        {
            Administrator administrator = currentUser as Administrator;


        }

        private static void ShowModeratorMenu()
        {
            Moderator moderator = currentUser as Moderator;
        }

        private static void ShowClientMenu()
        {
            Client client = currentUser as Client;
        }

        private static void UserEnterProgram()
        {
            bool flag = false;
            do
            {
                int choice;

                do
                {
                    Console.Write("Виберіть дію (1 - увійти, 2 - зареєструватися): ");
                } while ((!int.TryParse(Console.ReadLine(), out choice)) || (choice != 1 && choice != 2));

                if (choice == 1)
                {
                    flag = Login();
                }
                else
                {
                    Register();
                    flag = true;
                }

            } while (!flag);
        }

        public static void Register()
        {
            Console.Write("Придумайте логін: ");
            string login = Console.ReadLine();
            Console.Write("Придумайте пароль: ");
            string password = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Введіть вашу адресу: ");
            string address = Console.ReadLine();

            userController.RegisterNewClient(Guid.NewGuid(), name, login, password, address, storageController, ordersController);
            currentUser = userController.GetUser(login, password);
        }

        public static bool Login()
        {
            Console.Write("Введіть логін: ");
            string login = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

            User user = userController.GetUser(login, password);

            if(user == null)
            {
                Console.WriteLine("Користувача з такою комбінацією логіну і паролю не знайдено");
                return false;
            }

            currentUser = user;
            return true;
        }
    }
}