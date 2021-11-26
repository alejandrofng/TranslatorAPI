using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorAPI.Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class TranslationBasketLanguageConfiguration : IEntityTypeConfiguration<TranslationBasketLanguage>
    {
        public void Configure(EntityTypeBuilder<TranslationBasketLanguage> builder)
        {
            builder.HasKey(x => new { x.TranslationBasketId, x.LanguageId });
        }
    }
}
