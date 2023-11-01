using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Enums;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.DTO
{
    public class SufixDto
    {
        public SufixId SufixId { get; }
        public Lang CurrentLang { get; }
        public Phrase Value { get; }
        public Sufix SufixType { get; }

        public SufixDto(Lang currentLang, Phrase value, Sufix sufixType)
        {
            SufixId = Guid.NewGuid();
            CurrentLang = currentLang;
            Value = value;
            SufixType = sufixType;
        }
        public SufixDto()
        {
                
        }
    }
}
