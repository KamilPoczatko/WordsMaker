using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WordsMaker.Application.DTO;
using WordsMaker.Core.ValueObjects;
using WordsMaker.Core.ValueObjects.IDs;

namespace WordsMaker.Infrastructure.DAL.Configurations
{
    internal sealed class SufixDtoConfiguration : IEntityTypeConfiguration<SufixDto>
    {
        public void Configure(EntityTypeBuilder<SufixDto> builder)
        {
            builder.HasKey(x => x.SufixId);
            builder.Property(x => x.SufixId)
                .IsRequired()
                .HasConversion(x => x.Id, x => new SufixId(x));
            builder.Property(x => x.Value)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Phrase(x));
            builder.Property(x => x.CurrentLang)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Lang(x));
            builder.Property(x => x.SufixType);
        }
    }
}
