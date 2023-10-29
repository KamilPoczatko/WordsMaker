using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public class TranslationId : IdBase
    {
        public TranslationId(Guid id) : base(id) { }
        public TranslationId() : base() { }

        public static implicit operator Guid(TranslationId value) => value.Id;

        public static implicit operator TranslationId(Guid Value) => new TranslationId(Value);
    }
}
