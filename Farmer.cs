using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Farmer : Person
    {
        public Farmer(Farm farm,string name, string userType):base(name,userType) 
        {
            Farm = farm;
            Name= name;
            UserType=userType;
        }

        public Farm Farm {  get; set; }
    }
}
