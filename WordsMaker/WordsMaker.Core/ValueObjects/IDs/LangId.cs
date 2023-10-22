using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public class LangId : IdBase
    {
        public LangId(Guid id) : base(id) { }
        public LangId() : base() { }

        public static implicit operator Guid(LangId value) => value.Id;

        public static implicit operator LangId(Guid Value) => new LangId(Value);
    }
}
