using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class DictWord : IExpressionable
    {
        public Lang CurrentLang { get; }
        
        public Word Value { get; }
        public DictWord(Lang lang, Word value)
        {
            CurrentLang = lang;
            Value = value;
        }
    }
}
