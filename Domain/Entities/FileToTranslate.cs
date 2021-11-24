using System;
namespace TranslatorAPI.Domain.Models
{
    public class FileToTranslate
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Comments { get; set; }
        public virtual TranslationBasket TranslationBasket {get;set;}
        protected FileToTranslate()
        {

        }

        public FileToTranslate(Guid Id, Guid ProjectId, string Name, string Type, string Content, string Comments)
        {
            this.Id = Id;
            this.ProjectId = ProjectId;
            this.Name = Name;
            this.Type = Type;
            this.Content = Content;
            this.Comments = Comments;
        }
    }
}
