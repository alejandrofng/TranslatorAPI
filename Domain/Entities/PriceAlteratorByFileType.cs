using System;
using System.Collections.Generic;

namespace TranslatorAPI.Domain.Entities
{
    public class PriceAlteratorByFileType
    {
        public Guid Id { get; private set; }
        public bool IsDiscount { get; private set; }
        public decimal Percentage { get; private set; }
        public Guid FileTypeId { get; private set; }
        public virtual FileType FileType { get; set; }
        protected PriceAlteratorByFileType() { }
        public PriceAlteratorByFileType(Guid Id, Guid FileTypeId, bool IsDiscount, decimal Percentage)
        {
            this.Id = Id;
            this.FileTypeId = FileTypeId;
            this.IsDiscount = IsDiscount;
            this.Percentage = Percentage;
        }
    }
}
