using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public class ExpressionId : IdBase
    {
        public ExpressionId(Guid id) : base(id) { }
        public ExpressionId() : base() { }

        public static implicit operator Guid(ExpressionId value) => value.Id;

        public static implicit operator ExpressionId(Guid Value) => new ExpressionId(Value);
    }
}
