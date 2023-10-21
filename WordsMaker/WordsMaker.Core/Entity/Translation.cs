using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Exceptions;

namespace WordsMaker.Core.Entity
{
    public class Translation : ITranslatable
    {
        public IExpressionable CurrentWord { get; }
        public IExpressionable ForeignWord { get; }

        public Translation(IExpressionable currentWord, IExpressionable foreignWord)
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
