using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TranslatorAPI.DTO;
using TranslatorAPI.DTO.Extensions;
using TranslatorAPI.Infrastructure;

namespace TranslatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileToTranslateController : Controller
    {
        private TranslatorAPIContext Dbcontext { get; set; }
        public FileToTranslateController(TranslatorAPIContext context)
        {
            Dbcontext = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddFileToTranslationBasket dto)
        {
            try
            {
                Guid FileTypeId = Dbcontext.FileType.Where(x => x.Code == dto.FileType).Select(x => x.Id).First();
                FileToTranslate file = FileToTranslateExtensions.Map(dto, FileTypeId);
                await Dbcontext.FileToTranslate.AddAsync(file);
                await Dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
