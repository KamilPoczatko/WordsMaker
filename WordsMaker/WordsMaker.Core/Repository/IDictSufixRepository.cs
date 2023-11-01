using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Repository
{
    public interface IDictSufixRepository
    {
        Task<IEnumerable<DictSufix>> GetAllAsync();
        Task<DictSufix> GetAsync(SufixId SufixId);
        Task<IEnumerable<DictSufix>> GetAllByWordAsync(DictWord sourceWord);
        async Task<bool> IsExistsAsync(SufixId sufixId)
        {
            var DictSufix = await GetAsync(sufixId);
            return DictSufix != null;

        }

        Task AddAsync(DictSufix dictSufix);
        Task DeleteAsync(SufixId SufixId);
        Task AddRelatedWord(SufixId SufixId, DictWord relatedWord);
        Task AddRelatedWords(SufixId SufixId, IEnumerable<DictWord> relatedWords);


    }
}
