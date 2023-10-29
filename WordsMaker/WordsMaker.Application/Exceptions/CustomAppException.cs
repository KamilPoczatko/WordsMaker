using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Application.Exceptions
{
    public abstract class CustomAppException : Exception
    {
        public CustomAppException(string message) : base(message)
        {

        }
    }
}
