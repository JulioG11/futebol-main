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
        [HttpPost("transfer")]
        public IActionResult TransferPlayer([FromBody] transferirJogador transferirjogador)
        {
            try
            {
                _jogadorService.TransferJogador(transferirjogador.id_jogador, transferirjogador.timeOrigem, transferirjogador.timeDestino);
                return Ok("Transferência de jogador bem-sucedida.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
