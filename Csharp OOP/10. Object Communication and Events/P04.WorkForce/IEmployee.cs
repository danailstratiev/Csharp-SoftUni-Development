using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce
{
    public interface IEmployee
    {
        string Name { get; }

        int WorkHours { get; }
    }
}
