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
        IEnumerable<Phrase> PhrasesDiffMean { get; }
        DictPrefix Prefix { get; }
        DictPostfix Postfix { get; }

        public Aggregate(Translation translation, IEnumerable<DictWord> wordsDiffType, IEnumerable<Phrase> phrasesDiffMean, DictPrefix prefix, DictPostfix postfix)
        {
            Translation = translation;
            WordsDiffType = wordsDiffType;
            PhrasesDiffMean = phrasesDiffMean;
            Prefix = prefix;
            Postfix = postfix;
        }
    }
}
