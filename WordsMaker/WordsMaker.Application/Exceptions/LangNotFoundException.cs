using System;
using System.Runtime.Serialization;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.Exceptions
{
    public sealed class LangNotFoundException : CustomAppException
    {
        public Lang Lang { get; }

        public LangNotFoundException(Lang lang) : base($"Language {lang} not found.")
        {
            Lang = lang;
        }
    }
}