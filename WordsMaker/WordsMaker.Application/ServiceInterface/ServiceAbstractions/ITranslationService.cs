using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceAbstractions
{
    public interface ITranslationService
    {
        Task<IEnumerable<Translation>> GetAllAsync();
        Task<IEnumerable<Translation>> GetAsync(IExpressionable expressionable, DictLang foreignLang);
        void AddAsync(Translation translation);
        void DeleteAsync(TranslationId translationId);

        public async Task<bool> IsExistsAsync(IExpressionable expressionable, DictLang foreignLang)
        {
            var Translation = await GetAsync(expressionable, foreignLang);
            return Translation != null;

        }
    }
}
