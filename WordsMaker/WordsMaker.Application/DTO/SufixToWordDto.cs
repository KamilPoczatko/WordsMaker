using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.Enums;

namespace WordsMaker.Application.DTO
{
    public class SufixToWordDto
    {
        public SufixId SufixId { get; }
        public Lang CurrentLang { get; }
        public WordId WordId { get; }

        public SufixToWordDto(Lang currentLang, SufixId sufixId, WordId wordId) 
        {
            SufixId = sufixId;           
            CurrentLang = currentLang;
            WordId = wordId;
        }
    }
}
