using futebol.IService;
using futebol.Models;
using Microsoft.AspNetCore.Mvc;

namespace futebol.Controllers
{
    public class ExtraController : ControllerBase
    {
        private readonly IJogador _jogadorService;
        public ExtraController(IJogador jogador)
        {
            _jogadorService = jogador;
        }
        [HttpPost("transferir")]
        public IActionResult TransferirJogador([FromBody] transferirJogador transferirjogador)
        {
            try
            {
                var jogador = _jogadorService.TransferJogador(transferirjogador.id_jogador, transferirjogador.timeOrigem, transferirjogador.timeDestino);

                if (jogador == null)
                {
                    return NotFound("Jogador não encontrado ou times inválidos.");
                }

                return Ok("Transferência de jogador bem-sucedida.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}