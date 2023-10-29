﻿using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.DTO
{
    public class WordDto
    {
        public WordId WordId { get; }
        public Lang CurrentLang { get; }
        public Word Value { get; }
    }
}
