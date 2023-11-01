using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.DTO;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Configurations
{
    internal sealed class WordDtoConfiguration : IEntityTypeConfiguration<WordDto>
    {
        public void Configure(EntityTypeBuilder<WordDto> builder)
        {
            builder.HasKey(x => x.WordId);
            builder.Property(x => x.WordId)
                .IsRequired()
                .HasConversion(x => x.Id, x => new WordId(x));
            builder.Property(x => x.Value)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Word(x));
            builder.Property(x => x.CurrentLang)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Lang(x));
            builder.Property(x => x.Context);
                //.HasConversion(x => x, x => x);
            builder.Property(x => x.Type);
        }
    }
}
