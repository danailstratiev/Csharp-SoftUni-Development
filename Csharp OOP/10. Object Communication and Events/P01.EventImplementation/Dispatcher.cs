using System;
using System.Collections.Generic;
using System.Text;

namespace P01.EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange.Invoke(this, args);
        }
    }
}
