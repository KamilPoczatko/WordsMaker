using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public abstract class DictSufix
    {
        public Lang Lang { get; }
        public IEnumerable<Word> RelatedWords { get; }
        public Phrase Value { get; }
        public DictSufix(Lang lang, IEnumerable<Word> relatedWords, Phrase value)
        {
            Lang = lang;
            RelatedWords = relatedWords;
            Value = value;
        }
    }
}
