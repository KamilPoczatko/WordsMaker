using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Prefix
    {
        public string Value { get; private set; }
        public Prefix(string value)
        {
            Value = value;
        }

        public static implicit operator string(Prefix value) => value.Value;

        public static implicit operator Prefix(string Value) => new Prefix(Value);
    }
}
