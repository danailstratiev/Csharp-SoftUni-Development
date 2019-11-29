using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> _sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get
            {
                return this._sandwiches[name];
            }
            set
            {
                this._sandwiches[name] = value;
            }
        }
    }
}
