using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dz3Configuration
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } 
        public string Colour { get; set; }
        public List<string> Kittens { get; set; }
        public Owner Owner { get; set; }
    }
    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
