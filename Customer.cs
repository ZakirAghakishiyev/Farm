using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Customer:Person
    {
        public Customer(string name,decimal budget) : base(name)
        {
            Budget = budget;
            Name = name;
        }
        public decimal Budget {  get; set; }  
    }
}
