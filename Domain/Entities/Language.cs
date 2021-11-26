﻿using System;
using System.Collections.Generic;
namespace TranslatorAPI.Domain.Entities
{
    public class Language
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
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
