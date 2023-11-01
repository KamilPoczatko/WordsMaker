using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsMaker.Application.DTO;
using WordsMaker.Core.Entity;
using WordsMaker.Core.Enums;
using WordsMaker.Core.Repository;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Repositories
{
    public class DictSufixRepository : IDictSufixRepository
    {
        private readonly WordsMakerDbContext _dbContext;
        private readonly DbSet<SufixDto> _sufixes;
        private readonly DbSet<SufixToWordDto> _sufixToWord;
        private readonly DbSet<WordDto> _words;

        public DictSufixRepository(WordsMakerDbContext dbContext)
        {
            _dbContext = dbContext;
            _sufixes = _dbContext.DictSufixes;
            _sufixToWord = _dbContext.SufixToWord;
            _words = _dbContext.DictWords;
        }
        public Task AddAsync(DictSufix dictSufix)
        {
            var SufixToAdd = new SufixDto(dictSufix.CurrentLang, dictSufix.Value, dictSufix.SufixType);
            var SufixesToWordToAdd = dictSufix.RelatedWords.Select(x => new SufixToWordDto(x.CurrentLang, SufixToAdd.SufixId, x.WordId));
            
            _sufixes.Add(SufixToAdd);
            _sufixToWord.AddRange(SufixesToWordToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task AddRelatedWord(SufixId sufixId, DictWord relatedWord)
        {
            var SufixToWordToAdd = new SufixToWordDto(relatedWord.CurrentLang, sufixId, relatedWord.WordId);
            _sufixToWord.AddRange(SufixToWordToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task AddRelatedWords(SufixId SufixId, IEnumerable<DictWord> relatedWords)
        {
            var SufixesToWordToAdd = relatedWords.Select(x => new SufixToWordDto(x.CurrentLang, SufixId, x.WordId));
            _sufixToWord.AddRange(SufixesToWordToAdd);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(SufixId sufixId)
        {
            var SufixesToRemove = _sufixes.Where(x => x.SufixId == sufixId);
            _sufixes.RemoveRange(SufixesToRemove);

            var SufixesToWordsToRemove = _sufixToWord.Where(x => x.SufixId == sufixId);
            _sufixToWord.RemoveRange(SufixesToWordsToRemove);

            Task SaveChangesTask = _dbContext.SaveChangesAsync();
            Task.WaitAll(SaveChangesTask);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<DictSufix>> GetAllAsync()
            =>  GetSufixes(x => true);

        public async Task<IEnumerable<DictSufix>> GetAllByWordAsync(DictWord sourceWord)
        {
            var SetSufixes = _sufixToWord.Where(x => x.WordId == sourceWord.WordId).Select(x => x.SufixId);
            return GetSufixes(x =>  SetSufixes.Contains(x.SufixId));
        }

        public async Task<DictSufix> GetAsync(SufixId sufixId)
            => GetSufixes(x => x.SufixId == sufixId).FirstOrDefault();






        private IEnumerable<DictSufix> GetPrefixes(Func<SufixDto, bool> predicate)
            =>  _sufixes.Where(predicate)
            .Where(x => x.SufixType == Sufix.Prefix)
            .Select(x => new DictPrefix(
                    x.SufixId,
                    x.CurrentLang,
                    _sufixToWord.Where(w2s => w2s.SufixId == x.SufixId)
                                .Join(_words, w2ss => w2ss.WordId, w => w.WordId, (w2ss, w) => new DictWord(w.WordId, w.CurrentLang, w.Value)),
                    x.Value));


        private IEnumerable<DictSufix> GetPostfixes(Func<SufixDto, bool> predicate)
            => _sufixes.Where(predicate)
            .Where(x => x.SufixType == Sufix.Postfix)
            .Select(x => new DictPostfix(
                    x.SufixId,
                    x.CurrentLang,
                    _sufixToWord.Where(w2s => w2s.SufixId == x.SufixId)
                                .Join(_words, w2ss => w2ss.WordId, w => w.WordId, (w2ss, w) => new DictWord(w.WordId, w.CurrentLang, w.Value)),
                    x.Value));

        private IEnumerable<DictSufix> GetSufixes(Func<SufixDto, bool> predicate)
            => GetPrefixes(predicate)
            .Union(GetPostfixes(predicate));


    }
}
