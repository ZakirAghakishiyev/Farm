using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Animal:Base
    {
        private static int AutoIncremendId = 1;
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Animal(string name, decimal price)
        {
            Name = name;
            Price = price;
            Id= AutoIncremendId++;
        }
    }
}
