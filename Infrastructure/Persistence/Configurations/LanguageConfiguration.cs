using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorAPI.Domain.Models;

namespace TranslatorAPI.Infrastructure.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(5);
            builder.HasMany(x => x.TranslationBaskets)
                            .WithOne(x => x.Language);
        }
    }
}
