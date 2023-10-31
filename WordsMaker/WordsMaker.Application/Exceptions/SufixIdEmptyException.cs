using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.Exceptions
{
    public sealed class SufixIdEmptyException : CustomAppException
    {
        public SufixIdEmptyException()
            : base("Sufix id is empty")
        {

        }
    }
}
