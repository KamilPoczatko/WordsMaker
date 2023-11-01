using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.DTO;
using WordsMaker.Core.ValueObjects.IDs;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Infrastructure.DAL.Configurations
{
    internal sealed class SufixToWordDtoConfiguration : IEntityTypeConfiguration<SufixToWordDto>
    {
        public void Configure(EntityTypeBuilder<SufixToWordDto> builder)
        {
            builder.HasKey(x => new { x.WordId, x.SufixId});
            builder.Property(x => x.WordId)
                .IsRequired()
                .HasConversion(x => x.Id, x => new WordId(x));
            builder.Property(x => x.SufixId)
                .IsRequired()
                .HasConversion(x => x.Id, x => new SufixId(x));
            builder.Property(x => x.CurrentLang)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Lang(x));
        }
    }
}
