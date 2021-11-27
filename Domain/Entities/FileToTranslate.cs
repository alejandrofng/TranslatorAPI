using System;
namespace Domain.Entities
{
    public class FileToTranslate
    {
        public Guid Id { get; private set; }
        public Guid ProjectId { get; private set; }
        public string Name { get; private set; }
        public Guid FileTypeId { get; private set; }
        public virtual FileType FileType { get; private set; }
        public string Content { get; private set; }
        public string Comments { get; private set; }
        public virtual TranslationBasket TranslationBasket {get; private set; }
        protected FileToTranslate()
        {

        }

        public FileToTranslate(Guid ProjectId, string Name, Guid FileTypeId, string Content, string Comments)
        {
            this.ProjectId = ProjectId;
            this.Name = Name;
            this.FileTypeId = FileTypeId;
            this.Content = Content;
            this.Comments = Comments;
        }
        public FileToTranslate(Guid Id,Guid ProjectId, string Name, Guid FileTypeId, string Content, string Comments)
        {
            this.Id = Id;
            this.ProjectId = ProjectId;
            this.Name = Name;
            this.FileTypeId = FileTypeId;
            this.Content = Content;
            this.Comments = Comments;
        }
    }
}
