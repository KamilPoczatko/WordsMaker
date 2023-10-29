using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Abstractions;

namespace WordsMaker.Core.ValueObjects.IDs
{
    public abstract class IdBase : ITraceable
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
