using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.DTO;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Configurations
{
    internal sealed class TranslationDtoConfiguration : IEntityTypeConfiguration<TranslationDto>
    {
        public void Configure(EntityTypeBuilder<TranslationDto> builder)
        {
            builder.HasKey(x => new { x.CurrentWordId, x.ForeignWordId});
            builder.Property(x => x.CurrentWordId)
                .IsRequired()
                .HasConversion(x => x, x => new WordId(x));
            builder.Property(x => x.ForeignWordId)
                .IsRequired()
                .HasConversion(x => x, x => new WordId(x));
        }
    }
}
