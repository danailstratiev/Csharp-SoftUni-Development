using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeName) 
            : base(id, firstName, lastName)
        {
            this.CodeName = codeName;
        }

        public int CodeName { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Code Number: {this.CodeName}";
        }
    }
}
