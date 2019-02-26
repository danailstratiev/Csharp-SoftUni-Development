using System;
using System.Runtime.Serialization;

namespace Lab_03_Car_Constructors
{
    
    public class CarCannotContinueExeption : Exception
    {
        public CarCannotContinueExeption(string message) : base(message)
        {

        }        
    }
}