
using Domain.Entities;
using System;

namespace TranslatorAPI.DTO.Extensions
{
    public class FileToTranslateExtensions
    {
        public static FileToTranslate Map(AddFileToTranslationBasket dto, Guid FileTypeId)
        {
            return new FileToTranslate(
                dto.FileId,
                dto.ProjectId,
                dto.FileName,
                FileTypeId,
                dto.FileContent,
                dto.Comments);
        }
        public static FileToTranslateDTO Map(FileToTranslate model)
        {
            return new FileToTranslateDTO(model.Id,
                model.Name,
                model.FileType.Code,
                model.Comments);
        }
    }
}
