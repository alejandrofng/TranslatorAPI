using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorAPI.Models;

namespace TranslatorAPI.DTO
{
    public class FileToTranslateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public FileToTranslateDTO(Guid Id, string Name, string Type, string Comments)
        {
            this.Id = Id;
            this.Name = Name;
            this.Type = Type;
            this.Comments = Comments;
        }
        public static FileToTranslateDTO Map(FileToTranslate fileToTranslate)
        {
            return new FileToTranslateDTO(fileToTranslate.Id, fileToTranslate.Name, fileToTranslate.Type, fileToTranslate.Comments);
        }
    }
}
