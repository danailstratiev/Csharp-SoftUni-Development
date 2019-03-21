using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P06.Animals
{
    public class Tomcat : Cat
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
                
    }
}
