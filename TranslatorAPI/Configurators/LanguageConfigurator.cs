using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorAPI.Models;

namespace TranslatorAPI.Configurators
{
    public class LanguageConfigurator : IEntityTypeConfiguration<Language>
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
