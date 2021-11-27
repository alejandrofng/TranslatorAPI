using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence.Extensions;
using System;
using TranslatorAPI.DTO;
using TranslatorAPI.Infrastructure;

namespace TranslatorAPI.Validators
{
    public class AddTranslationBasketValidator : AbstractValidator<AddTranslationBasket>
    {
        public AddTranslationBasketValidator(TranslatorAPIContext dbContext)
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.DueDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.TargetLanguages).NotEmpty();
            RuleFor(x => x.ProjectId)
            .MustAsync( async (id,token) =>
            {

                    return ! await dbContext.ExistsAsync<TranslationBasket>(id, token);
            })
            .WithErrorCode("Supplied ProjectId already exists")
            .WithMessage("Value already exists");
            }
    }
}