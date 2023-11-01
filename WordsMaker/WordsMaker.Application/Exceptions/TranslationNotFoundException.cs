using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.Exceptions
{
    public sealed class TranslationNotFoundException : CustomAppException
    {
        public Phrase Phrase { get; }
        public Lang CurrentLang { get; }
        public Lang ForeignLang { get; }
        public TranslationNotFoundException(DictWord dictWord, Lang foreignLang) 
            : base($"Translation of word {dictWord.Phrase} from {dictWord.CurrentLang} to {foreignLang} not found")
        {
            Phrase = dictWord.Phrase;
            CurrentLang = dictWord.CurrentLang;
            ForeignLang = foreignLang;
        }
    }
}
