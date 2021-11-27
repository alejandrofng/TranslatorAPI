using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PriceAlterator:Entity
    {
        public bool IsDiscount { get; private set; }
        public decimal Percentage { get; private set; }
        public virtual ICollection<FileType> FileTypes { get; private set; }
        public virtual ICollection<Language> Languages { get; private set; }
        public PriceAlterator(Guid Id, bool IsDiscount, decimal Percentage):base(Id)
        {
            this.IsDiscount = IsDiscount;
            this.Percentage = Percentage;
        }
    }
}
