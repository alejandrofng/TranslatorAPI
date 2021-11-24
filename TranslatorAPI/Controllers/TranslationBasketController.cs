using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorAPI.Infrastructure;
using TranslatorAPI.DTO;

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
        public ViewTranslationBasket Get(Guid basketId)
        {
            ViewTranslationBasket result = _context.TranslationBasket.Include(x=>x.Files).Where(x => x.Id == basketId)
                .Select(x=>ViewTranslationBasket.Map(x)).FirstOrDefault();
            return result;
        }

        // POST api/<TranslationBasketController>
        [HttpPost]
        public void Post([FromBody] AddTranslationBasket dto)
        {
        }
        // POST api/<TranslationBasketController>
        [HttpPost("{basketId}/AddFile")]
        public void AddProduct([FromBody] AddFileToTranslationBasket dto, Guid basketId)
        {
        }
    }
}
