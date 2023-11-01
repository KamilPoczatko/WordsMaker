using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.Exceptions;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceDefinitions
{
    public class TranslationService : ITranslationService
    {
        private readonly IDictWordService _wordRepository;
        private readonly ITranslationService _translationRepository;

        public TranslationService(IDictWordService wordRepository, ITranslationService translationRepository)
        {
            _wordRepository = wordRepository;
            _translationRepository = translationRepository;
        }
        private void CreateOrFindWords(Translation translation)
        {
            Task TaskOfCurrentWord = CreateOrFindWordAsync(translation.CurrentWord);
            Task TaskOfForeignWord = CreateOrFindWordAsync(translation.ForeignWord);
            Task.WaitAll(TaskOfCurrentWord, TaskOfForeignWord);
        }
        private async Task<Task> CreateOrFindWordAsync(DictWord dictWord)
        {
            if(!await _wordRepository.IsExistsAsync(dictWord.WordId))
            {
                _wordRepository.AddAsync(dictWord);
            }
            return Task.CompletedTask;
        }
        public void AddAsync(Translation translation)
        {
            CreateOrFindWords(translation);

            _translationRepository.AddAsync(translation);
        }

        public void DeleteAsync(WordId currentWordId, WordId foreignWordId)
            => _translationRepository.DeleteAsync(currentWordId, foreignWordId);

        public Task<IEnumerable<Translation>> GetAllAsync()
            => _translationRepository.GetAllAsync();

        public Task<IEnumerable<Translation>> GetAsync(IExpressionable expressionable, DictLang foreignLang)
            => _translationRepository.GetAsync(expressionable, foreignLang);


    }
}
