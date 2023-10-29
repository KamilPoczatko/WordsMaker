using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.Enums;

namespace WordsMaker.Application.DTO
{
    public class SufixDto
    {
        public SufixId SufixId { get; }
        public Lang CurrentLang { get; }
        public Phrase Phrase { get; }
        public Sufix Sufix { get; }

        public SufixDto(Lang currentLang, Phrase phrase, SufixId sufixId, Sufix sufix) 
        {
            SufixId = sufixId;
            Phrase = phrase;
            CurrentLang = currentLang;
            Sufix = sufix;
        }
    }
}
