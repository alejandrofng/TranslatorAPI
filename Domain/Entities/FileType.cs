using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FileType:Entity
    {
        public string Code { get; private set; }
        public Guid? PriceAlteratorId { get; private set; }
        public virtual PriceAlterator PriceAlterator { get; private set; }
        public virtual ICollection<FileToTranslate> FileToTranslates { get; private set; }
        protected FileType()
        {

        }
        public FileType(Guid Id,string Code, Guid? PriceAlteratorId):base(Id)
        {
            this.Code = Code;
            this.PriceAlteratorId = PriceAlteratorId;
        }
    }
}
