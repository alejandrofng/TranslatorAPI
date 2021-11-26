using System.Collections.Generic;
using TranslatorAPI.Domain.Entities;

namespace Application
{
    public abstract class Command<T>
    {
        public abstract T Execute(List<FileToTranslate> files);
    }
}
