using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class Language:Entity
    {
        public string Code { get; private set; }
        public Guid? PriceAlteratorId { get; private set; }
        public virtual PriceAlterator PriceAlterator { get; set; }
        public virtual ICollection<TranslationBasketLanguage> TranslationBaskets { get; private set; }
        protected Language()
        {

        }
        public Language(Guid Id, string Code, Guid? PriceAlteratorId):base(Id)
        {
            this.Code = Code;
            this.PriceAlteratorId = PriceAlteratorId;
        }
    }
}
