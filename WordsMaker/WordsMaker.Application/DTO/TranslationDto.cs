using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.DTO
{
    public class TranslationDto
    {
        public WordId CurrentWordId { get; set; }
        public WordId ForeignWordId { get; set; }

        public TranslationDto(WordId currentWordId, WordId foreignWordId)
        {
            CurrentWordId = currentWordId;
            ForeignWordId = foreignWordId;
        }
    }
}
