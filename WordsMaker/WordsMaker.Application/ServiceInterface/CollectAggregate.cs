using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsMaker.Application.Exceptions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.ServiceInterface
{
    public class CollectAggregate
    {
        public Aggregate Aggregate { get; private set; }
        private readonly IDictSufixRepository _sufixRepository;
        private readonly IDictWordRepository _wordRepository;
        private readonly ITranslationRepository _translationRepository;
        private readonly ILangRepository _langRepository;

        public CollectAggregate(IDictSufixRepository sufixRepository, IDictWordRepository wordRepository, ITranslationRepository translationRepository, ILangRepository langRepository)
        {
            _sufixRepository = sufixRepository;
            _wordRepository = wordRepository;
            _translationRepository = translationRepository;
            _langRepository = langRepository;
        }

        public async void ProcessAggregate(DictWord dictWord, DictLang foreignLang)
        {

            var translations = await _translationRepository.GetAsync(dictWord, foreignLang);

            var currentTranslation = translations.FirstOrDefault(x => x.CurrentWord.Value.Context == dictWord.Value.Context);
            if (currentTranslation is null)
            {
                throw new TranslationNotFoundException(dictWord, foreignLang);
            }
            
            var sufixes = await _sufixRepository.GetAllByWordAsync(currentTranslation.ForeignWord);
            var prefix = sufixes.OfType<DictPrefix>().FirstOrDefault(x => x.SufixType == Sufix.Prefix);
            var postfix = sufixes.OfType<DictPostfix>().FirstOrDefault(x => x.SufixType == Sufix.Postfix);

            var wordsDiffMean = translations.Where(x => x.ForeignWord.Value.Context != dictWord.Value.Context).Select(s => new Phrase(s.ForeignWord.Value.Value));
            
            var wordsDiffType = _wordRepository.GetAllRelatedAsync(currentTranslation.ForeignWord);

            Aggregate = new Aggregate(currentTranslation, null, wordsDiffMean, prefix, postfix );


        }

        private async void ValidLang(DictLang dictLang)
        {
            if (! await _langRepository.IsExistsAsync(dictLang.LangId))
            {
                throw new LangNotFoundException(dictLang);
            }
        }


    }
}
