using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.Exceptions
{
    public sealed class LangAlreadyExistsException : CustomAppException
    {
        public Lang Lang { get; }

        public LangAlreadyExistsException(Lang lang) : base($"Language {lang} already exists.")
        {
            Lang = lang;
        }
    }
}
