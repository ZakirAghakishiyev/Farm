using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class Farm:Base
    {
        private static int AutoIncremendId = 1;

        public Farm(string name, Animal[] animals)
        {
            Name = name;
            Animals = animals;
            Id = AutoIncremendId++;
        }
        public Farm(string name, Animal[] animals, Farmer[] farmers) : this(name, animals)
        {            
            Farmers = farmers;
        }

        public string Name {  get; set; }
        public Animal[] Animals { get; set; }
        public Farmer[] Farmers { get; set; }

    }
}
