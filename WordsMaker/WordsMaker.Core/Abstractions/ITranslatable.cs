using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Abstractions
{
    public interface ITranslatable
    {
        //public IExpressionable Translate(IExpressionable expression, Lang foreignLangugage);
        public IExpressionable TranslateToCurrentLanguage();
        public IExpressionable TranslateToForeignLanguage();
    }
}
