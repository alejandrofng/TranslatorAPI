using System;
using System.Collections.Generic;
using System.Linq;
namespace TranslatorAPI.Domain.Models
{
    public class TranslationBasketLanguage
    {
        public Guid TranslationBasketId { get; set; }
        public virtual TranslationBasket TranslationBasket { get; set; }
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public TranslationBasketLanguage(Guid TranslationBasketId,Guid LanguageId)
        {
            this.TranslationBasketId = TranslationBasketId;
            this.LanguageId = LanguageId;
        }
    }
}
