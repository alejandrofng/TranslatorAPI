using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslatorAPI.DTO
{
    public class AddTranslationBasket
    {
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> TargetLanguages { get; set; }
    }
}
