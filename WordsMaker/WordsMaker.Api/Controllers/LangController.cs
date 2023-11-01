using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WordsMaker.Application.ServiceInterface.ServiceAbstractions;
using WordsMaker.Core.Entity;
using WordsMaker.Core.ValueObjects;

namespace WordsMaker.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LangController : ControllerBase
    {
        private readonly ILangService _langService;
        public LangController(ILangService langService)
        {
            _langService = langService;
        }
        [HttpGet]
        public async Task<ActionResult<DictLang>> Get()
        {
            
            return Ok(new Lang("PL"));
        }

        [HttpGet("{dictLang}")]
        public async Task<ActionResult<DictLang>> Get(DictLang dictLang)
        {
            var lang = _langService.GetAsync(dictLang.Lang);


            if (lang is null)
            {
                NotFound();
            }
            return Ok(lang);
        }
        [HttpPost]
        public ActionResult Post([FromBody] DictLang dictLang)
        {
            _langService.AddAsync(dictLang);

            //return Created("",dictLang);
            return CreatedAtAction(nameof(Get), new { dictLang = dictLang }, null);
        }
    }
}
