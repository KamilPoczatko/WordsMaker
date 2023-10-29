using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Repository;

namespace WordsMaker.Application.ServiceInterface
{
    public class CollectAggregate
    {
        public Aggregate Aggregate { get; }
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

        public void ProcessAggregate(DictWord dictWord, DictLang foreignLang)
        {
            //Translation translation = _translationRepository.
        }


    }
}
