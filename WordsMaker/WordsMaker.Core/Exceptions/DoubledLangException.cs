using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Exceptions
{
    public class DoubledLangException : CustomException
    {
        public Lang Lang { get; }
        public DoubledLangException(Lang lang)
            : base($"A language {lang} has been duplicated")
        {
            Lang = lang;
        }

    }
}
