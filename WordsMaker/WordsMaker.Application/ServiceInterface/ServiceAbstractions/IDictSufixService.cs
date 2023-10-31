using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.ServiceInterface.ServiceAbstractions
{
    public interface IDictSufixService
    {
        Task<IEnumerable<DictSufix>> GetAllAsync();
        Task<DictSufix> GetAsync(SufixId SufixId);
        Task<IEnumerable<DictSufix>> GetAllByWordAsync(DictWord sourceWord);
        public async Task<bool> IsExistsAsync(SufixId sufixId)
        {
            var DictSufix = await GetAsync(sufixId);
            return DictSufix != null;

        }

        void AddAsync(DictSufix dictSufix);
        void DeleteAsync(SufixId SufixId);
        void AddRelatedWord(SufixId SufixId, Word relatedWord);
        void AddRelatedWords(SufixId SufixId, IEnumerable<Word> relatedWords);
    }
}
