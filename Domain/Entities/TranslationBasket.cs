using System;
using System.Collections.Generic;
namespace TranslatorAPI.Domain.Models
{
    public class TranslationBasket
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }        
        public DateTime DueDate { get; set; }
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
