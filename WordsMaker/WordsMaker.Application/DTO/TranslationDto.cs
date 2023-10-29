using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.DTO
{
    public class TranslationDto
    {
        public TranslationId TranslationId { get; set; }
        public DictWord CurrentWord { get; set; }
        public DictWord ForeignWord { get; set; }

    }
}
