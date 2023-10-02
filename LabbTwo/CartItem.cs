using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwo
{
    internal class CartItem : Store 
    {
        public Product Product { get; }
        public int Quantity { get; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Product.Name} ({Quantity} items) - {CalculateTotalCost()} SEK";
        }

        

        internal double CalculateTotalCost()
        {
            return Product.Price * Quantity;
        }
    }
}
