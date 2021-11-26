using FluentValidation;
using System;
using TranslatorAPI.DTO;

namespace TranslatorAPI.Validators
{
    public class AddFileToTranslationBasketValidator : AbstractValidator<AddFileToTranslationBasket>
    {
        public AddFileToTranslationBasketValidator()
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.FileId).NotEmpty();
            RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.FileContent).NotEmpty();
            RuleFor(x => x.FileType).NotEmpty();
        }
    }
}