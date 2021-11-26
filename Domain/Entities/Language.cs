using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class Language
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public Guid PriceAlteratorId { get; private set; }
        public virtual PriceAlterator PriceAlterator { get; set; }
        public virtual ICollection<TranslationBasketLanguage> TranslationBaskets { get; set; }
        protected Language()
        {

        }
        public Language(Guid Id, string Code, Guid PriceAlteratorId)
        {
            this.Id = Id;
            this.Code = Code;
            this.PriceAlteratorId = PriceAlteratorId;
        }
    }
}
