using System;

namespace Завдання_12.User
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        protected string _login;
        protected string _password;
    }
}