using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwo
{
    internal class Customer : Store
    {
        public string Name { get; }
        public string Password { get; }
        public Cart Cart { get; }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            Cart = new Cart();
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public void AddToCart(Product product, int quantity) 
        { 
            Cart.AddItem(new CartItem(product, quantity));
        }

        public void EmptyCart()
        {
            Cart.Clear();
        }
    }
}
