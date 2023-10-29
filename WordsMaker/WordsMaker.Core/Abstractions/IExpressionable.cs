using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Abstractions
{
    public interface IExpressionable : ITraceable
    {
        public Lang CurrentLang { get; }
        public Phrase Phrase { get;  }
    }
}
