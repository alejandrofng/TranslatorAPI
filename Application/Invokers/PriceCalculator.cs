using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.Invokers
{
    public class PriceCalculator
    {
        public decimal Calculate(TranslationBasket basket)
        {
            CalculatePriceCommand command = new(basket);
            return command.Execute();            
        }
    }
}
