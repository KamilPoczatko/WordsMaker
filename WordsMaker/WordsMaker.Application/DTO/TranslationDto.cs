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
        public DictWord CurrentWordId { get; set; }
        public DictWord ForeignWordId { get; set; }

    }
}
