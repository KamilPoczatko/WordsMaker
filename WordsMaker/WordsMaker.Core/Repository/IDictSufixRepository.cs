using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Core.Repository
{
    public interface IDictSufixRepository
    {
        Task<IEnumerable<DictSufix>> GetAllAsync();
        Task<bool> IsExistsAsync(DictSufix dictSufix);
        Task AddAsync(DictSufix dictSufix);
        Task DeleteAsync(DictSufix dictSufix);
        Task AddRelatedWord(DictSufix dictSufix, Word relatedWord);
        Task AddRelatedWords(DictSufix dictSufix, IEnumerable<Word> relatedWords);


    }
}
