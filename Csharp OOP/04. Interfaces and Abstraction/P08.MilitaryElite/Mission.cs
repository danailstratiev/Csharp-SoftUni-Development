using System;

namespace P08.MilitaryElite
{
    public class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get => this.state;
            internal set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid Mission");
                }

                this.state = value;
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
