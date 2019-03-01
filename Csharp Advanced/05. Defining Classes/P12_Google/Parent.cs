using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
   public class Parent
    {
        //•	“< Name > parents<parentName> < parentBirthday >”

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}"; 
        }
    }
}
