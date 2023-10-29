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
        Task<IEnumerable<Lang>> GetAllAsync();
        Task<DictLang> GetAsync(LangId langId);
        async Task<bool> IsExistsAsync(LangId langId)
        {
            var DictLang = await GetAsync(langId);
            return DictLang != null;

        }
        Task AddAsync(Lang lang);
        Task DeleteAsync(LangId langId);
    }
}
