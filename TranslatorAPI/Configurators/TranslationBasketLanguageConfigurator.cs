using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorAPI.Models;

namespace TranslatorAPI.Configurators
{
    public class TranslationBasketLanguageConfigurator : IEntityTypeConfiguration<TranslationBasketLanguage>
    {
        public void Configure(EntityTypeBuilder<TranslationBasketLanguage> builder)
        {
            builder.HasKey(x => new { x.TranslationBasketId, x.LanguageId });
        }
    }
}
