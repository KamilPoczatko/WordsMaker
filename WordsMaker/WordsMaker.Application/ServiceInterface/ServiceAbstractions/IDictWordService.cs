using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceAbstractions
{
    public interface IDictWordService
    {
        Task<IEnumerable<DictWord>> GetAllAsync();
        Task<DictWord> GetAsync(WordId WordId);
        Task<IEnumerable<DictWord>> GetAllRelatedAsync(DictWord dictWord);
        async Task<bool> IsExistsAsync(WordId WordId)
        {
            var dictWord = await GetAsync(WordId);
            return dictWord != null;
        }
        void AddAsync(DictWord DictWord);
        void DeleteAsync(WordId WordId);
    }
}
