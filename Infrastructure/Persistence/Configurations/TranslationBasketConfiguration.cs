using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class TranslationBasketConfiguration : IEntityTypeConfiguration<TranslationBasket>
    {
        public void Configure(EntityTypeBuilder<TranslationBasket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.CustomerId)
            .IsRequired();

            builder.Property(x => x.DueDate)
                .IsRequired();

            builder.HasMany(x => x.Files)
                .WithOne(x => x.TranslationBasket);

            builder.HasMany(x => x.Languages)
                .WithOne(x => x.TranslationBasket);
        }
    }
}
