using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.DTO;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL
{
    public sealed class WordsMakerDbContext : DbContext
    {
        public DbSet<LangDto> DictLangs { get; set; }
        public DbSet<SufixDto> DictSufixes { get; set; }
        public DbSet<SufixToWordDto> SufixToWord { get; set; }
        public DbSet<WordDto> DictWords { get; set; }
        public DbSet<TranslationDto> Translations { get; set; }
        

        public WordsMakerDbContext(DbContextOptions<WordsMakerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
