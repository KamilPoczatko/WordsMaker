using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.Exceptions;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Application.ServiceInterface.ServiceDefinitions
{
    public class LangService : ILangService
    {
        private readonly ILangRepository _langRepository;

        public LangService(ILangRepository langRepository)
        {
            _langRepository = langRepository;
        }

        public async void AddAsync(Lang lang)
        {
            if(await _langRepository.IsExistsByLangAsync(lang))
            {
                throw new LangAlreadyExistsException(lang);
            }
            await _langRepository.AddAsync(lang);
        }

        public void DeleteAsync(LangId langId)
            => _langRepository.DeleteAsync(langId);

        public Task<IEnumerable<Lang>> GetAllAsync()
            => _langRepository.GetAllAsync();

        public Task<DictLang> GetAsync(LangId langId)
            => _langRepository.GetAsync(langId);
    }
}
