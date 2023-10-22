using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Entity
{
    public class DictLang
    {
        public Lang Lang { get; }
        public LangId LangId { get; }

    }
}
