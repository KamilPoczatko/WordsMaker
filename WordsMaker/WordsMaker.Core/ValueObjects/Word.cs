using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Enums;

namespace WordsMaker.Core.ValueObjects
{
    public class Word : Phrase
    {
        public WordType Type { get; set; }
        public string Context { get; set; }
        public Word(string value, WordType type = WordType.Noun, string context = "") : base(value)
        {
            Type = type;
            Context = context;
        }
        public Word(string value) : base(value)
        {
            Type = WordType.Noun;
            Context = "";
        }

        public static implicit operator string(Word value) => value.Value;

        public static implicit operator Word(string Value) => new Word(Value);
    }
}
