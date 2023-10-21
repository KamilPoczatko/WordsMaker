using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsMaker.Core.ValueObjects
{
    public class Expresion
    {
        public IList<Word> Words => Expresion.GetWords(Value);
        public string Value { get; private set; }
        public Expresion(string value)
        {
            Value = value;
        }

        public static implicit operator string(Expresion value) => value.Value;

        public static implicit operator Expresion(string Value) => new Expresion(Value);

        public static IList<Word> GetWords(string expression)
        {
            IList<Word> words = new List<Word>();
            var dividedString = expression.Split(' ');

            foreach (var word in dividedString)
            {
                words.Add(word);
            }

            return words;
        }
    }
}
