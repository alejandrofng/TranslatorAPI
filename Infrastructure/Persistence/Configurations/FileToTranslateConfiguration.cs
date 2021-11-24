using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorAPI.Domain.Models;

namespace TranslatorAPI.Infrastructure.Configurations
{
    public class FileToTranslateConfiguration : IEntityTypeConfiguration<FileToTranslate>
    {
        public void Configure(EntityTypeBuilder<FileToTranslate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired();
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(140);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Comments)
                .HasMaxLength(500);

            builder.HasOne(x => x.TranslationBasket)
                .WithMany()
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
                
        }
    }
}
