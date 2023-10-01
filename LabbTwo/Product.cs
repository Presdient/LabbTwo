using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwo
{
    internal class Product : Store
    {
        public string Name { get; }
        public double Price { get; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
