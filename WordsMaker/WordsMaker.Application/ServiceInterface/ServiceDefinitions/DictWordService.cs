using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.DTO;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceDefinitions
{
    public class DictWordService : IDictWordService
    {
        private readonly IDictWordRepository _dicWordRepository;

        public DictWordService(IDictWordRepository dicWordRepository)
        {
            _dicWordRepository = dicWordRepository;
        }

        public async void AddAsync(DictWord DictWord)
            => await _dicWordRepository.AddAsync(DictWord);
        

        public async void DeleteAsync(WordId WordId)
            => await _dicWordRepository.DeleteAsync(WordId);

        public async Task<IEnumerable<DictWord>> GetAllAsync()
            => await _dicWordRepository.GetAllAsync();

        public async Task<IEnumerable<DictWord>> GetAllRelatedAsync(DictWord dictWord)
        {
            var RelatedWords = await _dicWordRepository.GetAllRelatedAsync(dictWord);
            var OtherTypeWords = RelatedWords.Where(x => x.Value.Type != dictWord.Value.Type);
            return OtherTypeWords;
        }
            

        public async Task<DictWord> GetAsync(WordId WordId)
            => await _dicWordRepository.GetAsync(WordId);
    }
}
