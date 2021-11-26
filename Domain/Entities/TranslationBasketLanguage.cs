using System;
using System.Collections.Generic;
using System.Linq;
namespace Domain.Entities
{
    public class TranslationBasketLanguage
    {
        public Guid TranslationBasketId { get; private set; }
        public virtual TranslationBasket TranslationBasket { get; private set; }
        public Guid LanguageId { get; private set; }
        public virtual Language Language { get; private set; }

        public TranslationBasketLanguage(Guid TranslationBasketId,Guid LanguageId)
        {
            this.TranslationBasketId = TranslationBasketId;
            this.LanguageId = LanguageId;
        }
        public TranslationBasketLanguage(Language Language)
        {
            this.Language = Language;
        }
    }
}
