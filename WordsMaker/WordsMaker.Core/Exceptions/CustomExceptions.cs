using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.Exceptions
{
    public abstract class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
