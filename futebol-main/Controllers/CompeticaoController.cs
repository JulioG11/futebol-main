using futebol.IService;
using futebol.Models;
using futebol.Services;
using Microsoft.AspNetCore.Mvc;

namespace futebol.Controllers
{
    public class CompeticaoController : ControllerBase
    {
        private readonly ICompeticao _competicaoService;

        public CompeticaoController(ICompeticao competicao)
        {
            _competicaoService = competicao;
        }

        [HttpPost("competicao")]
        public IActionResult Post([FromBody] competicao Competicao)
        {
            if (Competicao == null) return BadRequest();
            return Ok(_competicaoService.Create(Competicao));
        }

        [HttpGet("competicao")]
        public IActionResult Get()
        {
            return Ok(_competicaoService.FindAll());
        }

        [HttpPut("competicao")]
        public IActionResult Put([FromBody] competicao Competicao)
        {
            if (Competicao == null) return BadRequest();
            return Ok(_competicaoService.Update(Competicao));
        }

        [HttpDelete("competicao/{nome_competicao}")]
        public IActionResult Delete(string nome_competicao)
        {
            _competicaoService.Delete(nome_competicao);
            return NoContent();
        }
    }
}
