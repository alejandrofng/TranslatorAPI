using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorAPI.Domain.Models;

namespace TranslatorAPI.Infrastructure.Configurations
{
    public class TranslationBasketLanguageConfiguration : IEntityTypeConfiguration<TranslationBasketLanguage>
    {
        public void Configure(EntityTypeBuilder<TranslationBasketLanguage> builder)
        {
            builder.HasKey(x => new { x.TranslationBasketId, x.LanguageId });
        }
    }
}
