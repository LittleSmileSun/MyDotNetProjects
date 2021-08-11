using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dz3Configuration
{
    public class AngularComponentConfigClass
    {
        public Import Import { get; set; }
        public @Component @Component { get; set; }
        public ComponentClass ComponentClass { get; set; }
    }

    public class Import
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class @Component
    {
        public string Dependency { get; set; }
    }

    public class ComponentClass
    {
        public string Name { get; set; }
        public Variable Variable { get; set; }
    }

    public class Variable
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}