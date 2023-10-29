using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Repository
{
    public interface IDictWordRepository
    {
        Task<IEnumerable<DictWord>> GetAllAsync();
        Task<DictWord> GetAsync(WordId WordId);
        Task<IEnumerable<DictWord>> GetAllRelatedAsync(DictWord dictWord);        
        async Task<bool> IsExistsAsync(WordId WordId)
        {
            var dictWord = await GetAsync(WordId);
            return dictWord != null;
        }
        Task AddAsync(DictWord DictWord);
        Task DeleteAsync(WordId WordId);
    }
}
