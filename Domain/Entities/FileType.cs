using System;
using System.Collections.Generic;

namespace TranslatorAPI.Domain.Entities
{
    public class FileType
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        protected FileType()
        {

        }
        public FileType(Guid Id,string Code)
        {
            this.Id = Id;
            this.Code = Code;
        }
    }
}
