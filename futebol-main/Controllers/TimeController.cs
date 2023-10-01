using futebol.IService;
using futebol.Models;
using futebol.View;
using Microsoft.AspNetCore.Mvc;

namespace futebol.Controllers
{
    public class TimeController : ControllerBase
    {
        private readonly ITime _timeService;

        public TimeController(ITime time)
        {
            _timeService = time;
        }

        [HttpPost("time")]
        public IActionResult Post([FromBody] timeView Time)
        {
            if (Time == null) return BadRequest();
            return Ok(_timeService.Create(Time));
        }

        [HttpGet("time")]
        public IActionResult Get()
        {
            return Ok(_timeService.FindAll());
        }

        [HttpPut("time")]
        public IActionResult Put([FromBody] timeView Time)
        {
            if (Time == null) return BadRequest();
            return Ok(_timeService.Update(Time));
        }

        [HttpDelete("time/{nome_time}")]
        public IActionResult Delete(string nome_time)
        {
            _timeService.Delete(nome_time);
            return NoContent();
        }
    }
}
