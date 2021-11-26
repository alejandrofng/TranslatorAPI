using System;
namespace TranslatorAPI.Domain.Entities
{
    public class FileToTranslate
    {
        public Guid Id { get; private set; }
        public Guid ProjectId { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Content { get; private set; }
        public string Comments { get; private set; }
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
