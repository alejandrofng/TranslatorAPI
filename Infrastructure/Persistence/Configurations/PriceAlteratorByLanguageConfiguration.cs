using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorAPI.Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class PriceAlteratorByLanguageConfiguration : IEntityTypeConfiguration<PriceAlteratorByLanguage>
    {
        public void Configure(EntityTypeBuilder<PriceAlteratorByLanguage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.IsDiscount)
                .IsRequired();
            builder.Property(x => x.Percentage)
                .HasDefaultValue(0)
                .IsRequired();

        }
    }
}
