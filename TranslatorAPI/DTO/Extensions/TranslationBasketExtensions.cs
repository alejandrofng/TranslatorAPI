using Domain.Entities;
using System.Linq;

namespace TranslatorAPI.DTO.Extensions
{
    public class TranslationBasketExtensions
    {
        public static ViewTranslationBasket Map(TranslationBasket TranslationBasket, decimal Price)
        {
            return new ViewTranslationBasket(TranslationBasket.Id,
                TranslationBasket.CustomerId,
                TranslationBasket.DueDate,
                Price,
                TranslationBasket.Files.Select(x => FileToTranslateDTO.Map(x)).ToList());
        }
        public static TranslationBasket Map(AddTranslationBasket dto)
        {
            return new TranslationBasket(dto.ProjectId,
                dto.CustomerId,
                dto.DueDate);
        }
    }
}
