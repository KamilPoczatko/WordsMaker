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

        public async void AddAsync(DictLang lang)
        {
            if(await _langRepository.IsExistsAsync(lang.Lang))
            {
                throw new LangAlreadyExistsException(lang.Lang);
            }
            await _langRepository.AddAsync(lang);
        }

        public void DeleteAsync(Lang lang)
            => _langRepository.DeleteAsync(lang);

        public Task<IEnumerable<DictLang>> GetAllAsync()
            => _langRepository.GetAllAsync();

        public Task<DictLang> GetAsync(Lang lang)
            => _langRepository.GetAsync(lang);
    }
}
