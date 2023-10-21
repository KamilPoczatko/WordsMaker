using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Postfix
    {
        public string Value { get; private set; }
        public Postfix(string value)
        {
            Value = value;
        }

        public static implicit operator string(Postfix value) => value.Value;

        public static implicit operator Postfix(string Value) => new Postfix(Value);
    }
}
