
using Domain.Entities;
using System;

namespace TranslatorAPI.DTO.Extensions
{
    public class FileToTranslateExtensions
    {
        public static FileToTranslate Map(AddFileToTranslationBasket dto, Guid FileTypeId)
        {
            return new FileToTranslate(Guid.NewGuid(),dto.ProjectId,
                dto.FileName,
                FileTypeId,
                dto.FileContent,
                dto.Comments);
        }
    }
}
