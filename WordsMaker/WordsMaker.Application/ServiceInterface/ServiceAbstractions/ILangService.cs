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
        Task<IEnumerable<Lang>> GetAllAsync();
        Task<DictLang> GetAsync(LangId langId);
        async Task<bool> IsExistsAsync(LangId langId)
        {
            var DictLang = await GetAsync(langId);
            return DictLang != null;
        }
        void AddAsync(Lang lang);
        void DeleteAsync(LangId langId);
    }
}
