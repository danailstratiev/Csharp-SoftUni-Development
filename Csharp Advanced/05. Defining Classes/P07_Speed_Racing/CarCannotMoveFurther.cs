using System;
using System.Runtime.Serialization;

namespace P07_Speed_Racing
{
    public class CarCannotMoveFurther : Exception
    {
        public CarCannotMoveFurther(string message) : base(message)
        {
        }
    }
}