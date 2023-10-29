using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Entity;

namespace WordsMaker.Core.Repository
{
    public interface ITranslationRepository
    {
        Task<IEnumerable<Translation>> GetAllAsync();        
        Task<IEnumerable<Translation>> GetAsync(IExpressionable expressionable, DictLang foreignLang);
        Task<bool> IsExistsAsync(Translation translation);
        Task AddAsync(Translation translation);
        Task DeleteAsync(Translation translation);
    }
}
