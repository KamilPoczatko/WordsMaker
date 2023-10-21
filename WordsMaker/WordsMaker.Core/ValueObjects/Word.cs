using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Word
    {
        public string Value { get; private set; }
        public Word(string value)
        {
            Value = value;
        }

        public static implicit operator string(Word value) => value.Value;

        public static implicit operator Word(string Value) => new Word(Value);
    }
}
