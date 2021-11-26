using System.Collections.Generic;
using System.Linq;
using TranslatorAPI.Domain.Entities;

namespace Application.Invokers
{
    public class PriceCalculator
    {
        public decimal Calculate(List<FileToTranslate> Files)
        {
            CalculatePriceCommand command = new();
            return command.Execute(Files);            
        }
    }
}
