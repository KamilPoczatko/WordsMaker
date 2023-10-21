using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Lang
    {
        public string Value { get; private set; }
        public Lang(string value)
        {
            Value = value;
        }

        public static implicit operator string(Lang value) => value.Value;

        public static implicit operator Lang(string Value) => new Lang(Value);
    }
}
