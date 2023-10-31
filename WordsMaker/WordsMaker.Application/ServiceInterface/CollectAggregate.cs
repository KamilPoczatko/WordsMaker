using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsMaker.Application.Exceptions;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.ServiceInterface
{
    public class CollectAggregate
    {
        public Aggregate Aggregate { get; private set; }
        private readonly IDictSufixService _sufixService;
        private readonly IDictWordService _wordService;
        private readonly ITranslationService _translationService;
        private readonly ILangService _langService;

        public CollectAggregate(IDictSufixService sufixService, 
                                IDictWordService wordService, 
                                ITranslationService translationService, 
                                ILangService langService)
        {
            _sufixService = sufixService;
            _wordService = wordService;
            _translationService = translationService;
            _langService = langService;
        }

        public async void ProcessAggregate(DictWord dictWord, DictLang foreignLang)
        {
            ValidLang(dictWord.CurrentLang);
            ValidLang(foreignLang);

            var translations = await _translationService.GetAsync(dictWord, foreignLang);

            var currentTranslation = translations.FirstOrDefault(x => x.CurrentWord.Value.Context == dictWord.Value.Context);
            if (currentTranslation is null)
            {
                throw new TranslationNotFoundException(dictWord, foreignLang);
            }
            
            var sufixes = await _sufixService.GetAllByWordAsync(currentTranslation.ForeignWord);
            var prefix = sufixes.OfType<DictPrefix>().FirstOrDefault(x => x.SufixType == Sufix.Prefix);
            var postfix = sufixes.OfType<DictPostfix>().FirstOrDefault(x => x.SufixType == Sufix.Postfix);

            var wordsDiffMean = translations.Where(x => x.ForeignWord.Value.Context != dictWord.Value.Context)
                                            .Select(s => new Phrase(s.ForeignWord.Value.Value));
            
            var wordsDiffType = _wordService.GetAllRelatedAsync(currentTranslation.ForeignWord);

            Aggregate = new Aggregate(currentTranslation, null, wordsDiffMean, prefix, postfix );


        }

        private async void ValidLang(DictLang dictLang)
        {
            if(!await _langService.IsExistsAsync(dictLang.LangId))
            {
                throw new LangNotFoundException(dictLang);
            }
        }


    }
}
