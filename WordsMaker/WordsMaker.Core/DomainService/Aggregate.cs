using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.DomainService
{
    public class Aggregate
    {
        Translation Translation { get; }
        IEnumerable<DictWord> WordsDiffTypes { get; }
        Prefix? Prefix { get; }
        Postfix? Postfix { get; }
    }
}
