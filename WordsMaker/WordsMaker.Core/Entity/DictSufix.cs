using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public abstract class DictSufix : Phrase, IExpressionable
    {
        SufixId SufixId { get; }
        public Lang CurrentLang { get; }
        public IEnumerable<Word> RelatedWords { get; }
        public Phrase Phrase => Value;
        public Guid Id => SufixId;

        public DictSufix(SufixId sufixId ,Lang lang, IEnumerable<Word> relatedWords, Phrase value) : base(value)
        {
            SufixId = sufixId;
            CurrentLang = lang;
            RelatedWords = relatedWords;
        }
    }
}
