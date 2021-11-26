using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

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

    }
}
