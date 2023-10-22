using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public class SufixId : IdBase
    {
        public SufixId(Guid id) : base(id) { }
        public SufixId() : base() { }

        public static implicit operator SufixId(LangId value) => value.Id;

        public static implicit operator SufixId(Guid Value) => new SufixId(Value);
    }
}
