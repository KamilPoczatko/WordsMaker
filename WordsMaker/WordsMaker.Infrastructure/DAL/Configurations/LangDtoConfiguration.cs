using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WordsMaker.Application.DTO;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Infrastructure.DAL.Configurations
{
    internal class LangDtoConfiguration : IEntityTypeConfiguration<LangDto>
    {
        public void Configure(EntityTypeBuilder<LangDto> builder)
        {
            builder.HasKey(x => x.Lang);
            builder.Property(x => x.Lang)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Lang(x));
        }

    }
}