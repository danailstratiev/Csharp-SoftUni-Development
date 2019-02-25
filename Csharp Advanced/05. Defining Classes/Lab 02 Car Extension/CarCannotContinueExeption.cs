using System;


namespace Lab_02_Car_Extension
{
    public class CarCannotContinueExeption : Exception
    {
        public CarCannotContinueExeption(string message)
            : base(message)
        {

        }
    }
}
