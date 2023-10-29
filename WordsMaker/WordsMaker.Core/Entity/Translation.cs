using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Exceptions;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public class Translation : ITranslatable, ITraceable
    {
        TranslationId TranslationId { get; }
        public DictWord CurrentWord { get; }
        public DictWord ForeignWord { get; }

        public Guid Id => TranslationId;

        public Translation(DictWord currentWord, DictWord foreignWord)
        {
            if(currentWord.CurrentLang == foreignWord.CurrentLang)
            {
                throw new DoubledLangException(currentWord.CurrentLang.Lang);
            }

            CurrentWord = currentWord;
            ForeignWord = foreignWord;
        }

        public IExpressionable TranslateToCurrentLanguage()
            => CurrentWord;

        public IExpressionable TranslateToForeignLanguage()
            => ForeignWord;
    }
}
