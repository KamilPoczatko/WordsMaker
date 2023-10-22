using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public abstract class IdBase
    {
        public Guid Id { get; }

        public IdBase(Guid id)
        {
            Id = id;
        }
        public IdBase()
        {
            Id = Guid.Empty;
        }
    }
}
