using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Abstractions
{
    public interface IExpressionable
    {
        public Lang CurrentLang { get; }
        public Word Value { get; }
    }
}
