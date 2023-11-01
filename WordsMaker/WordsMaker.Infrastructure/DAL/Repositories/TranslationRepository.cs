using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.DTO;
using WordsMaker.Core.Abstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly WordsMakerDbContext _dbContext;
        private readonly DbSet<TranslationDto> _translations;
        private readonly DbSet<WordDto> _words;

        public TranslationRepository(WordsMakerDbContext dbContext)
        {
            _dbContext = dbContext;
            _translations = _dbContext.Translations;
            _words = _dbContext.DictWords;
        }
        public Task AddAsync(Translation translation)
        {
            var TranslationToAdd = new TranslationDto(translation.CurrentWord.WordId, translation.ForeignWord.WordId);
            _translations.Add(TranslationToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(WordId currentWordId, WordId foreignWordId)
        {
            var TranslationsToRemove = _translations.WhereAlternately(currentWordId, foreignWordId);
            _translations.RemoveRange(TranslationsToRemove);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Translation>> GetAllAsync()
            => _translations.ToTranslations(_words);

        public async Task<IEnumerable<Translation>> GetAsync(IExpressionable expressionable, DictLang foreignLang)
            => GetAllAsync().Result.Where(x => x.CurrentWord.WordId == expressionable.Id && x.ForeignWord.CurrentLang == foreignLang.Lang);

        public Task<Translation> GetAsync(WordId currentWordId, WordId foreignWordId)
            => _translations.ToTranslationsWithIds(_words, currentWordId, foreignWordId).FirstAsync();


    } 
    public static class Extension
    {
        public static IQueryable<TranslationDto> WhereAlternately(this DbSet<TranslationDto> translations, WordId currentWordId, WordId foreignWordId)
        {
            return translations.Where(x => (x.CurrentWordId == currentWordId && x.ForeignWordId == foreignWordId)
                                        || (x.CurrentWordId == foreignWordId && x.ForeignWordId == currentWordId));
        }
        public static IQueryable<TranslationDto> WhereAlternately(this DbSet<TranslationDto> translations, WordId currentWordId)
        {
            return translations.Where(x => (x.CurrentWordId == currentWordId)
                                        || (x.ForeignWordId == currentWordId));
        }
        public static IQueryable<Translation> ToTranslationsWithIds(this DbSet<TranslationDto> translations, DbSet<WordDto> words, WordId currentWordId, WordId foreignWordId)
            => translations.WhereAlternately(currentWordId, foreignWordId).Select(x => new Translation(words.FirstOrDefault(y => y.WordId == x.CurrentWordId).ToDictWord(),
                                                        words.FirstOrDefault(y => y.WordId == x.CurrentWordId).ToDictWord()));
        public static IQueryable<Translation> ToTranslations(this DbSet<TranslationDto> translations, DbSet<WordDto> words)
            => translations.Select(x => new Translation(words.FirstOrDefault(y => y.WordId == x.CurrentWordId).ToDictWord(),
                                                        words.FirstOrDefault(y => y.WordId == x.CurrentWordId).ToDictWord()));
        public static DictWord ToDictWord(this WordDto wordDto)
        {
            return new DictWord(wordDto.WordId, wordDto.CurrentLang, wordDto.Value);
        }
    }
}
