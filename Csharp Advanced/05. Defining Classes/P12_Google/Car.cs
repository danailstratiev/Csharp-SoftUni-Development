using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
   public class Car
    {
        //•	“< Name > car<carModel> < carSpeed >”

        public string Model { get; set; }

        public int Speed { get; set; }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}"; 
        }
    }
}
