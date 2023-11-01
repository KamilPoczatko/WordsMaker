using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.DTO;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Repositories
{
    public class LangRepository : ILangRepository
    {
        private readonly WordsMakerDbContext _dbContext;
        private readonly DbSet<LangDto> _dictLangs;

        public LangRepository(WordsMakerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dictLangs = _dbContext.DictLangs;
        }

        public Task AddAsync(DictLang dictLang)
        {
            LangDto LangToAdd = new LangDto(dictLang.Lang);
            _dictLangs.Add(LangToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Lang lang)
        {
            var LangsToRemove = _dictLangs.Where(x => x.Lang == lang);
            _dictLangs.RemoveRange(LangsToRemove);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<DictLang>> GetAllAsync()
            =>await _dictLangs.Select(x => new DictLang(x.Lang)).ToListAsync();

        public async Task<DictLang> GetAsync(Lang lang)
        {
            var LangDto = await _dictLangs.SingleOrDefaultAsync(x => x.Lang == lang);
            return new DictLang(LangDto.Lang);
        }
            

    }
}
