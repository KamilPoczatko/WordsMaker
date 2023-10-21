using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Phrase
    {
        public string Value { get; private set; }
        public Phrase(string value)
        {
            Value = value;
        }

        public static implicit operator string(Phrase value) => value.Value;

        public static implicit operator Phrase(string Value) => new Phrase(Value);
    }
}
