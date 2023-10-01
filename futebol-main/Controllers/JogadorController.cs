using futebol.IService;
using futebol.View;
using Microsoft.AspNetCore.Mvc;

namespace futebol.Controllers
{
    public class JogadorController : ControllerBase
    {
        private readonly IJogador _jogadorService;

        public JogadorController(IJogador jogador)
        {
            _jogadorService = jogador;
        }

        [HttpPost("jogador")]
        public IActionResult Post([FromBody] jogadorView jogadorVM)
        {
            if (jogadorVM == null) return BadRequest();
            return Ok(_jogadorService.Create(jogadorVM));
        }

        [HttpGet("jogador/{nome_time}")]
        public IActionResult Get(string nome_time)
        {
            return Ok(_jogadorService.FindAll(nome_time));
        }

        [HttpPut("jogador")]
        public IActionResult Put([FromBody] jogadorView Jogador)
        {
            if (Jogador == null) return BadRequest();
            return Ok(_jogadorService.Update(Jogador));
        }

        [HttpDelete("jogador/{id_jogador}")]
        public IActionResult Delete(long id_jogador)
        {
            _jogadorService.Delete(id_jogador);
            return NoContent();
        }
    }
}
