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
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationBasketController : ControllerBase
    {
        private TranslatorAPIContext _context { get; set; }
        public TranslationBasketController(TranslatorAPIContext context)
        {
            _context = context;
        }
        // GET: api/<TranslationBasketController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return _context.TranslationBasket.ToList();
        }

        // GET api/<TranslationBasketController>/5
        [HttpGet("{basketId}")]
        public IActionResult Get(Guid basketId)
        {
            try
            {
                var basket = _context.TranslationBasket.Include(x => x.Files).Include(x => x.Languages).Where(x => x.Id == basketId).FirstOrDefault();
                PriceCalculator pc = new();
                decimal price = pc.Calculate(basket);
                ViewTranslationBasket result = TranslationBasketExtensions.Map(basket, price);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TranslationBasketController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTranslationBasket dto)
        {
            try
            {
                var basket = TranslationBasketExtensions.Map(dto);
                var languages = _context.Language.Where(x => dto.TargetLanguages.Contains(x.Code)).ToList();
                languages.ForEach(l => basket.AddLanguage(l));
                await _context.Set<TranslationBasket>().AddAsync(basket);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get),basket.Id);
            }
            catch
            {
                return BadRequest();
            }
            

        }
        // POST api/<TranslationBasketController>
        [HttpPost("{basketId}/AddFile")]
        public async Task<ActionResult> AddFile([FromBody] AddFileToTranslationBasket dto, Guid basketId)
        {
            dto.ProjectId = basketId;
            Guid FileTypeId = _context.FileType.Where(x => x.Code == dto.FileType).Select(x=>x.Id).First();
            FileToTranslate file = FileToTranslateExtensions.Map(dto,FileTypeId);
            await _context.FileToTranslate.AddAsync(file);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
