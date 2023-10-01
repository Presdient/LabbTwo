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
            return $"{Product.Name} ({Quantity} items) - {CalulateTotalCost()} SEK";
        }

        private object CalulateTotalCost()
        {
            throw new NotImplementedException();
        }

        internal double CalculateTotalCost()
        {
            throw new NotImplementedException();
        }
    }
}
