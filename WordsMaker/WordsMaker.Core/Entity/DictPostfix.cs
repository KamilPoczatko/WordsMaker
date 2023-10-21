using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class DictPostfix : DictSufix
    {
        
        public DictPostfix(Lang lang, IEnumerable<Word> relatedWords, Phrase value) : base(lang, relatedWords, value)
        {
        }
    }
}
