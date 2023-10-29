using System;
using System.Runtime.Serialization;
using WordsMaker.Core.Entity;

namespace WordsMaker.Application.Exceptions
{
    public class LangNotFoundException : CustomAppException
    {
        public DictLang DictLang { get; }

        public LangNotFoundException(DictLang dictLang) : base($"Language {dictLang.Lang} not found.")
        {
            DictLang = dictLang;
        }
    }
}