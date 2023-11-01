using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class DictWordRepository : IDictWordRepository
    {
        private readonly WordsMakerDbContext _dbContext;
        private readonly DbSet<WordDto> _dictWords;

        public DictWordRepository(WordsMakerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dictWords = _dbContext.DictWords;
        }
        public Task AddAsync(DictWord dictWord)
        {
            var WordToAdd = new WordDto(dictWord.CurrentLang, 
                                        dictWord.Value.Value, 
                                        dictWord.Value.Type, 
                                        dictWord.Value.Context);
            _dictWords.Add(WordToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(WordId WordId)
        {
            var WordsToRemove = _dictWords.Where(x => x.WordId == WordId);
            _dictWords.RemoveRange(WordsToRemove);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<DictWord>> GetAllAsync()
            => _dictWords.Select(x => new DictWord(x.WordId, x.CurrentLang, x.Value));

        public Task<IEnumerable<DictWord>> GetAllRelatedAsync(DictWord dictWord)
            => throw new NotImplementedException();
        //TODO: implement GetAllRelatedAsync

        public async Task<DictWord> GetAsync(WordId WordId)
        { 
            var WordToGet = await _dictWords.SingleOrDefaultAsync(x => x.WordId == WordId);
            return new DictWord(WordToGet.WordId, WordToGet.CurrentLang, WordToGet.Value);
        }
    }
}
