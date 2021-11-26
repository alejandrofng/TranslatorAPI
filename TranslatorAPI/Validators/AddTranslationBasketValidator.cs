using FluentValidation;
using System;
using TranslatorAPI.DTO;

namespace TranslatorAPI.Validators
{
    public class AddTranslationBasketValidator : AbstractValidator<AddTranslationBasket>
    {
        public AddTranslationBasketValidator()
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.DueDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.TargetLanguages).NotEmpty();
        }
    }
}