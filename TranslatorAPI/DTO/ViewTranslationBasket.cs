using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorAPI.Domain.Models;

namespace TranslatorAPI.DTO
{
    public class ViewTranslationBasket
    {
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }
        public string DueDate { get; set; }
        public string RemainingTime { get; set; }
        public List<FileToTranslateDTO> Files { get; set; }
        public decimal Price { get; set; }
        public ViewTranslationBasket(Guid ProjectId, Guid CustomerId, DateTime DueDate,decimal Price, List<FileToTranslateDTO> Files)
        {
            this.ProjectId = ProjectId;
            this.CustomerId = CustomerId;
            this.DueDate = DueDate.ToString("dd/MM/yyyy hh:mm");
            RemainingTime = (DateTime.Now - DueDate).ToString(@"d\.hh\:mm\:ss");
            this.Files = Files;            
            this.Price = Price;
        }
        public static ViewTranslationBasket Map(TranslationBasket TranslationBasket, CalculatePriceCommand command)
        {
            decimal Price = command.Execute(TranslationBasket.Files.Select(x=>x.Content).ToList());
            return new ViewTranslationBasket(TranslationBasket.Id,
                TranslationBasket.CustomerId,
                TranslationBasket.DueDate,
                Price,
                TranslationBasket.Files.Select(x=>FileToTranslateDTO.Map(x)).ToList());
        }
    }
}
