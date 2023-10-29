using System;
using System.Collections.Generic;
using System.Text;

namespace WordsMaker.Core.Abstractions
{
    public interface ITraceable
    {
        public Guid Id { get; }
    }
}
