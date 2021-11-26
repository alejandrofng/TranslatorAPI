using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FileType
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public Guid PriceAlteratorId { get; private set; }
        public virtual PriceAlterator PriceAlterator { get; set; }
        public virtual ICollection<FileToTranslate> FileToTranslates { get; set; }
        protected FileType()
        {

        }
        public FileType(Guid Id,string Code, Guid PriceAlteratorId)
        {
            this.Id = Id;
            this.Code = Code;
            this.PriceAlteratorId = PriceAlteratorId;
        }
    }
}
