using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Entity
{
    public class Aggregate
    {
        public Translation Translation { get; }
        public IEnumerable<DictWord> WordsDiffType { get; }
        public IEnumerable<Phrase> PhrasesDiffMean { get; }
        public DictPrefix Prefix { get; }
        public DictPostfix Postfix { get; }

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
