using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
   public class BadRequestException : Exception
    {
        private const string BadRequestExceptionDefaulMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            :this (BadRequestExceptionDefaulMessage)
        {

        }

        public BadRequestException(string name)
            :base(name)
        {

        }
    }
}
