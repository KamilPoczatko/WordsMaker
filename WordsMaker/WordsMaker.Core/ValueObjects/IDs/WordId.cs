using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public class WordId : IdBase
    {
       

        public WordId(Guid id) : base(id) { }
        public WordId() : base() { }

        public static implicit operator WordId(LangId value) => value.Id;

        public static implicit operator WordId(Guid Value) => new WordId(Value);
    }
}
