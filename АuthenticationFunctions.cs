using System;
using Завдання_12.UserClasses;

namespace Завдання_12
{
    public class АuthenticationFunctions
    {
        public static void UserEnterProgram()
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

            Program.userController.RegisterNewClient(Guid.NewGuid(), name, login, password, address, Program.storageController, Program.ordersController);
            Program.currentUser = Program.userController.GetUser(login, password);
        }

        public static bool Login()
        {
            Console.Write("Введіть логін: ");
            string login = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

            User user = Program.userController.GetUser(login, password);

            if (user == null)
            {
                Console.WriteLine("Користувача з такою комбінацією логіну і паролю не знайдено");
                return false;
            }

            Program.currentUser = user;
            return true;
        }
    }
}
