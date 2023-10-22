using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class Aggregate
    {
        Translation Translation { get; }
        IEnumerable<DictWord> WordsDiffType { get; }
        IEnumerable<DictWord> WordsDiffMean { get; }
        Prefix Prefix { get; }
        Postfix Postfix { get; }
    }
}
