using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.DTO
{
    public class LangDto
    {
        public Lang Lang { get; set; }
        public LangDto(Lang lang)
        {
            Lang = lang;
        }
        public LangDto()
        {                
        }
    }
}
