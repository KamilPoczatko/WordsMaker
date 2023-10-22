using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.DomainService
{
    public interface IWordsMakerCoreService
    {
        Task<IEnumerable<Aggregate>> GetAllAsync();
        Task<bool> IsExistsAsync(Aggregate aggregate);
        Task AddAsync(Aggregate aggregate);
        Task DeleteAsync(Aggregate aggregate);        
    }
}
