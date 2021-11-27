using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class TranslationBasket: Entity
    {
        public Guid CustomerId { get; private set; }        
        public DateTime DueDate { get; private set; }
        public virtual ICollection<FileToTranslate> Files { get; private set; }

        private readonly List<TranslationBasketLanguage> _Languages = new();
        public virtual IReadOnlyList<TranslationBasketLanguage> Languages => _Languages;
        protected TranslationBasket() {  }

        public TranslationBasket(
            Guid Id,
            Guid CustomerId, 
            DateTime DueDate
            ):base(Id)
        {
            this.CustomerId = CustomerId;
            this.DueDate = DueDate;
        }

        public void AddLanguage(Language language)
        {
            if (_Languages.All(x => x.Language != language))
                _Languages.Add(new TranslationBasketLanguage(language));
        }
    }
}
