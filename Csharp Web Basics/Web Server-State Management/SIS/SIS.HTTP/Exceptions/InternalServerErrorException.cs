using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
   public class InternalServerErrorException : Exception
    {
        private const string InternalServerErrorExceptionDefaulMessage = "The Server has encountered an error.";

        public InternalServerErrorException()
            : this(InternalServerErrorExceptionDefaulMessage)
        {

        }

        public InternalServerErrorException(string name)
            : base(name)
        {

        }
    }
}
