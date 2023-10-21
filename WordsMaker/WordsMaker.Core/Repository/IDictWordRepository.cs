using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;

namespace WordsMaker.Core.Repository
{
    public interface IDictWordRepository
    {
        Task<IEnumerable<DictWord>> GetAllAsync();        
        Task<bool> IsExistsAsync(DictWord DictWord);
        Task AddAsync(DictWord DictWord);
        Task DeleteAsync(DictWord DictWord);
    }
}
