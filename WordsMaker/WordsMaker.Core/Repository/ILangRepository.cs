using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Repository
{
    public interface ILangRepository
    {
        Task<IEnumerable<DictLang>> GetAllAsync();
        Task<DictLang> GetAsync(Lang lang);        
        async Task<bool> IsExistsAsync(Lang lang)
        {
            var DictLang = await GetAsync(lang);
            return DictLang != null;
        }
        Task AddAsync(DictLang lang);
        Task DeleteAsync(Lang lang);
    }
}
