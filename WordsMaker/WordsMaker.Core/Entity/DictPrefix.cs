using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Enums;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class DictPrefix : DictSufix
    {
        Sufix SufixType => Sufix.Prefix;
        public DictPrefix(Lang lang, IEnumerable<Word> relatedWords, Phrase value) : base(lang, relatedWords, value)
        {
        }
    }
}
