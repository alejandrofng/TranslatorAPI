using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorAPI.Models;

namespace TranslatorAPI.DTO
{
    public class ViewTranslationBasket
    {
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DueDate { get; set; }
        public TimeSpan RemainingTime => DateTime.Now - DueDate;
        public List<FileToTranslateDTO> Files { get; set; }
        public decimal Price { get; set; }
        public ViewTranslationBasket(Guid ProjectId, Guid CustomerId, DateTime DueDate, List<FileToTranslateDTO> Files)
        {
            this.ProjectId = ProjectId;
            this.CustomerId = CustomerId;
            this.DueDate = DueDate;
            this.Files = Files;
        }
        public static ViewTranslationBasket Map(TranslationBasket TranslationBasket)
        {
            return new ViewTranslationBasket(TranslationBasket.Id,
                TranslationBasket.CustomerId,
                TranslationBasket.DueDate,
                TranslationBasket.Files.Select(x=>FileToTranslateDTO.Map(x)).ToList());
        }
    }
}
