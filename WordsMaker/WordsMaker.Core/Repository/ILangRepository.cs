using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Repository
{
    public interface ILangRepository
    {
        Task<IEnumerable<Lang>> GetAllAsync();
        Task<bool> IsExistsAsync(Lang lang);
        Task AddAsync(Lang lang);
        Task DeleteAsync(Lang lang);
    }
}
