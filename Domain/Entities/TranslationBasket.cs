using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class TranslationBasket
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }        
        public DateTime DueDate { get; private set; }
        public virtual ICollection<FileToTranslate> Files { get; set; }
        public virtual ICollection<TranslationBasketLanguage> Languages { get; set; }
        protected TranslationBasket() {  }

        public TranslationBasket(
            Guid Id,
            Guid CustomerId, 
            DateTime DueDate
            )
        {
            this.CustomerId = CustomerId;
            this.Id = Id;
            this.DueDate = DueDate;
        }
    }
}
