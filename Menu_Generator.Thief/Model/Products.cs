using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Model
{
    public class Products
    {
        public Products(List<Product> items)
        {
            Items = items;
        }

        public List<Product> Items { get; }
    }
}
