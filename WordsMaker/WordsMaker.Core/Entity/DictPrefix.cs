using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class DictPrefix
    {
        public Lang Lang { get; }
        public Word Word { get; }
        public DictPrefix(Lang lang, Word word)
        {
            Lang = lang;
            Word = word;
        }

    }
}
