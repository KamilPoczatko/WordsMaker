using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.Exceptions
{
    public sealed class DictSufixNotFoundException : CustomAppException 
    {
        public SufixId SufixId { get; }
        public DictSufixNotFoundException(SufixId sufixId)
            : base($"Sufix with {sufixId} id not found")
        {
           
        }
    }
}
