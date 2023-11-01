using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public class DictWord : IExpressionable
    {
        public WordId WordId { get; }
        public Word Value { get; }
        public Lang CurrentLang { get; }       
        public Phrase Phrase => Value;
        public Guid Id => WordId;

        Lang IExpressionable.CurrentLang => CurrentLang;

        public DictWord(WordId wordId, Lang lang, Word value)
        {
            WordId = wordId;
            CurrentLang = lang;
            Value = value;
        }
    }
}
