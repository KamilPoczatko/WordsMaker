using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;

namespace WordsMaker.Core.DomainService
{
    public class WordsMakerCoreService : IWordsMakerCoreService
    {
        public Task AddAsync(Aggregate aggregate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Aggregate aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aggregate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(Aggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
