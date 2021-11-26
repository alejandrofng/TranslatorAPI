using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslatorAPI.DTO
{
    public class AddFileToTranslationBasket
    {
        public Guid FileId { get; set; }
        public Guid ProjectId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileContent { get; set; }
        public string Comments { get; set; }
    }
}
