using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Customer:Person
    {
        public Customer(string name, string userType,decimal budget) : base(name, userType)
        {
            Budget = budget;
            Name = name;
            UserType = userType;
        }
        public decimal Budget {  get; set; }  
    }
}
