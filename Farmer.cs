using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Farmer : Person
    {
        public Farmer(Farm farm,string name):base(name) 
        {
            Farm = farm;
            Name= name;
        }

        public Farm Farm {  get; set; }
    }
}
