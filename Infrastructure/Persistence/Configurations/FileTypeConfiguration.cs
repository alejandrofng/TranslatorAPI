using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(10);
            builder.HasOne(x => x.PriceAlterator)
            .WithMany(x => x.FileTypes)
            .IsRequired(false)
            .HasForeignKey(x => x.PriceAlteratorId);
        }
    }
}
