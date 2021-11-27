using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
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
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(5);
            builder.HasMany(x => x.TranslationBaskets)
                            .WithOne(x => x.Language);

            builder.HasOne(x => x.PriceAlterator)
                .WithMany(x => x.Languages)
                .IsRequired(false)
                .HasForeignKey(x => x.PriceAlteratorId);
        }
    }
}
