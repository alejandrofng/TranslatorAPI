using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslatorAPI.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public virtual ICollection<TranslationBasketLanguage> TranslationBaskets { get; set; }
        protected Language()
        {

        }
        public Language(Guid Id, string Code)
        {
            this.Id = Id;
            this.Code = Code;
        }
    }
}
