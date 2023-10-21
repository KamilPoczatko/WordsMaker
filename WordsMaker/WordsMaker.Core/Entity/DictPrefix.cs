﻿using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class DictPrefix : DictSufix
    {
        public DictPrefix(Lang lang, IEnumerable<Word> relatedWords, Phrase value) : base(lang, relatedWords, value)
        {
        }
    }
}
