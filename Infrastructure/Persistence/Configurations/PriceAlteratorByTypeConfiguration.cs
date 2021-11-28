using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class PriceAlteratorConfiguration : IEntityTypeConfiguration<PriceAlterator>
    {
        public void Configure(EntityTypeBuilder<PriceAlterator> builder)
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
