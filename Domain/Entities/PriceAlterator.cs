using System;

namespace Domain.Entities
{
    public class PriceAlterator
    {
        public Guid Id { get; private set; }
        public bool IsDiscount { get; private set; }
        public decimal Percentage { get; private set; }
        public PriceAlteratorByFileType(Guid Id, Guid FileTypeId, bool IsDiscount, decimal Percentage)
        {
            this.Id = Id;
            this.FileTypeId = FileTypeId;
            this.IsDiscount = IsDiscount;
            this.Percentage = Percentage;
        }
    }
}
