using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Enums;

namespace WordsMaker.Core.ValueObjects
{
    public class Word
    {
        public string Value { get; private set; }
        public WordType Type { get; private set; }
        public string? Context { get; private set; }
        public Word(string value, WordType type = WordType.Noun, string context = null)
        {
            Value = value;
            Type = type;
            Context = context;
        }

        public static implicit operator string(Word value) => value.Value;

        public static implicit operator Word(string Value) => new Word(Value);
    }
}
