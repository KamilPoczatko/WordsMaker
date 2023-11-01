using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Core.Repository
{
    public interface ITranslationRepository
    {
        Task<IEnumerable<Translation>> GetAllAsync();        
        Task<IEnumerable<Translation>> GetAsync(IExpressionable expressionable, DictLang foreignLang);
        Task<Translation> GetAsync(WordId currentWordId, WordId foreignWordId);
        Task<Translation> GetAsync(Translation translation)
            => GetAsync(translation.CurrentWord.WordId, translation.ForeignWord.WordId);
        async Task<bool> IsExistsAsync(WordId currentWordId, WordId foreignWordId)
        {
            Translation TranslationExistsing = await GetAsync(currentWordId, foreignWordId);
            return TranslationExistsing != null;
        } 
        async Task<bool> IsExistsAsync(Translation translation)
        {
            Translation TranslationExistsing = await GetAsync(translation.CurrentWord.WordId, translation.ForeignWord.WordId);
            return TranslationExistsing != null;
        }
        Task AddAsync(Translation translation);
        Task DeleteAsync(WordId currentWordId, WordId foreignWordId);
    }
}
