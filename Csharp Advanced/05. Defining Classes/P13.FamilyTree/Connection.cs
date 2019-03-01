using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P13.FamilyTree
{
    public class Connection
    {
        public Connection(Person parent, Person child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public Person Parent { get; set; }

        public Person Child { get; set; }
    }
}
