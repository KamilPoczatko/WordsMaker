using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Exceptions;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public class Translation : ITranslatable
    {
        public DictWord CurrentWord { get; }
        public DictWord ForeignWord { get; }

        public Translation(DictWord currentWord, DictWord foreignWord)
        {
            if(currentWord.CurrentLang == foreignWord.CurrentLang)
            {
                throw new DoubledLangException(currentWord.CurrentLang);
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
