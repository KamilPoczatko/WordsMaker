﻿using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Enums;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public class DictPrefix : DictSufix
    {
        public override Sufix SufixType => Sufix.Prefix;
        public DictPrefix(SufixId sufixId,Lang lang, IEnumerable<DictWord> relatedWords, Phrase value) : base(sufixId, lang, relatedWords, value)
        {
        }
    }
}
