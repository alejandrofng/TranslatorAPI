using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorAPI.Infrastructure;
using TranslatorAPI.DTO;
using Application.Invokers;
using TranslatorAPI.DTO.Extensions;
using Domain.Entities;
using System.Threading.Tasks;

namespace TranslatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationBasketController : ControllerBase
    {
        private TranslatorAPIContext DbContext { get; set; }
        public TranslationBasketController(TranslatorAPIContext context)
        {
            DbContext = context;
        }

        // GET api/<TranslationBasketController>/5
        [HttpGet("{basketId}")]
        public IActionResult Get(Guid basketId)
        {
            var basket = DbContext.TranslationBasket.Include(x => x.Files).Include(x => x.Languages).Where(x => x.Id == basketId).FirstOrDefault();
            if (basket == null)
                return NotFound("The projectId supplied does not exist.");
            PriceCalculator pc = new();
            decimal price = pc.Calculate(basket);
            ViewTranslationBasket result = TranslationBasketExtensions.Map(basket, price);
            return Ok(result);
        }

        // POST api/<TranslationBasketController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTranslationBasket dto)
        {
            var basket = TranslationBasketExtensions.Map(dto);
            var languages = DbContext.Language.Where(x => dto.TargetLanguages.Contains(x.Code.ToLower())).ToList();
            languages.ForEach(l => basket.AddLanguage(l));
            await DbContext.Set<TranslationBasket>().AddAsync(basket);
            await DbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),basket.Id);
        }
    }
}
