using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Application.ServiceInterface.ServiceAbstractions
{
    public interface ILangService
    {
        Task<IEnumerable<DictLang>> GetAllAsync();
        Task<DictLang> GetAsync(Lang lang);
        async Task<bool> IsExistsAsync(Lang lang)
        {
            var DictLang = await GetAsync(lang);
            return DictLang != null;
        }
        void AddAsync(DictLang dictLang);
        void DeleteAsync(Lang lang);
    }
}
