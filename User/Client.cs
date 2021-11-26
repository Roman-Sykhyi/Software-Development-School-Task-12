﻿using System;
using System.Collections.Generic;
using Завдання_12.Purchase;
using Завдання_12.Purchase.Order;
using Завдання_12.StorageClasses;

namespace Завдання_12.UserClasses
{
    public class Client : User
    {
        public ClientType Type { get; private set; }

        public string Address { get; private set; }

        private Cart _cart;

        private IStorageViewer _storageViewer;
        private IOrderCreator _orderCreator;

        public Client(Guid id, string name, string login, string password, string address, IStorageViewer storageViewer, IOrderCreator orderCreator)
            : base(id, name, login, password)
        {
            Type = ClientType.New;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            _storageViewer = storageViewer ?? throw new ArgumentNullException(nameof(storageViewer));
            _orderCreator = orderCreator ?? throw new ArgumentNullException(nameof(orderCreator));

            _cart = new Cart();
        }

        public void SetType(ClientType clientType)
        {
            Type = clientType;
        }

        public IReadOnlyList<(Product, int)> ShowStorage()
        {
            return _storageViewer.GetProducts();
        }

        public void ConfirmOrder(bool shouldDeliver)
        {
            _orderCreator.CreateOrder(_cart.Purchases, Id, Type, shouldDeliver);
        }
    }
}