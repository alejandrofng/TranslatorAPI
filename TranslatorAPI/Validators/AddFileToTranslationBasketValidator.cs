﻿using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence.Extensions;
using System;
using TranslatorAPI.DTO;
using TranslatorAPI.Infrastructure;

namespace TranslatorAPI.Validators
{
    public class AddFileToTranslationBasketValidator : AbstractValidator<AddFileToTranslationBasket>
    {
        public AddFileToTranslationBasketValidator(TranslatorAPIContext dbContext)
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.FileId).NotEmpty();
            RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.FileContent).NotEmpty();
            RuleFor(x => x.FileType).NotEmpty();
            RuleFor(x => x.FileId)
            .MustAsync(async (id, token) =>
            {

                return !await dbContext.ExistsAsync<FileToTranslate>(id, token);
            })
            .WithErrorCode("Supplied FileId already exists")
            .WithMessage("Value already exists");
        }
    }
    }
}