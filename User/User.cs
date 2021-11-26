using System;

namespace Завдання_12.UserClasses
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Login { get; private set; }
        public string Password { get; private set; }

        protected User(Guid id, string name, string login, string password)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}