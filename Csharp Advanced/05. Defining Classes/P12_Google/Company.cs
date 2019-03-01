using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
   public class Company
    {
        //•	“< Name > company<companyName> 
        // < department > < salary >” 

        public string Name { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Department} {this.Salary:F2}";
        }
    }
}
