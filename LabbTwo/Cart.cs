using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwo
{
    internal class Cart : Store
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            items.Add(item);
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (var item in items) 
            {
                totalCost += item.CalculateTotalCost();
            }
            return totalCost;
        }

        public void Clear()
        {
            items.Clear();
        }

        public override string ToString()
        {
            if (items.Count == 0)
            {
                return ("Cart is empty.");
            }

            var cartItems = new List<string>();
            foreach (var item in items)
            {
                cartItems.Add(item.ToString());
            }
            return string.Join("\n", cartItems);




        }
    }
}
