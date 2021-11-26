using System;
using System.Collections.Generic;

namespace TranslatorAPI.Domain.Entities
{
    public class PriceAlteratorByLanguage
    {
        public Guid Id { get; private set; }
        public bool IsDiscount { get; private set; }
        public decimal Percentage { get; private set; }
        public Guid LanguageId { get; private set; }
        public virtual Language Language { get; set; }
        protected PriceAlteratorByLanguage() { }
        public PriceAlteratorByLanguage(Guid Id,Guid LanguageId, bool IsDiscount, decimal Percentage)
        {
            this.Id = Id;
            this.LanguageId = LanguageId;
            this.IsDiscount = IsDiscount;
            this.Percentage = Percentage;
        }
    }
}
