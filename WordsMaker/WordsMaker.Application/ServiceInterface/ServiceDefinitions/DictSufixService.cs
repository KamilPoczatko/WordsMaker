using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.Exceptions;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceDefinitions
{
    public class DictSufixService : IDictSufixService
    {
        private readonly IDictSufixRepository _dictSufixRepository;

        public DictSufixService(IDictSufixRepository dictSufixRepository)
        {
            _dictSufixRepository = dictSufixRepository;
        }

        
        private async void IsSufixValid(SufixId sufixId)
        {
            if (sufixId == Guid.Empty)
            {
                throw new SufixIdEmptyException();
            }

            var DictSufix = await GetAsync(sufixId);            
            if (DictSufix is null)
            {
                throw new DictSufixNotFoundException(sufixId);
            }
        }

        public void AddAsync(DictSufix dictSufix)
            => _dictSufixRepository.AddAsync(dictSufix);

        public async void AddRelatedWord(SufixId sufixId, Word relatedWord)
        {
            IsSufixValid(sufixId);

            await _dictSufixRepository.AddRelatedWord(sufixId, relatedWord);
        }

        public async void AddRelatedWords(SufixId sufixId, IEnumerable<Word> relatedWords)
        {
            IsSufixValid(sufixId);

            await _dictSufixRepository.AddRelatedWords(sufixId, relatedWords);
        }

        public void DeleteAsync(SufixId SufixId)
            => _dictSufixRepository.DeleteAsync(SufixId);

        public Task<IEnumerable<DictSufix>> GetAllAsync()
            => _dictSufixRepository.GetAllAsync();

        public Task<IEnumerable<DictSufix>> GetAllByWordAsync(DictWord sourceWord)
            => _dictSufixRepository.GetAllByWordAsync(sourceWord);

        public Task<DictSufix> GetAsync(SufixId SufixId)
            => _dictSufixRepository.GetAsync(SufixId);
    }
}
