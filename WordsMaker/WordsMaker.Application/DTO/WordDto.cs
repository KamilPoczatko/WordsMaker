using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.Enums;

namespace WordsMaker.Application.DTO
{
    public class WordDto
    {
        public WordId WordId { get; set; }
        public Lang CurrentLang { get; set; }
        public Word Value { get; set; }
        public WordType Type => Value.Type;
        public string Context => Value.Context;

        public WordDto(Lang currentLang, Word value, WordType type, string context)
        {
            CurrentLang = currentLang;
            Value = value;
            Value.Type = type;
            Value.Context = context;
            WordId = Guid.NewGuid();
        }
    }
}
