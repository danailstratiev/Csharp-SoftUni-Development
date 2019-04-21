using MortalEngines.IO.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public IList<ICommand> ReadCommands()
        {
            var allComands = new List<ICommand>();

            return allComands;
        }
    }
}
