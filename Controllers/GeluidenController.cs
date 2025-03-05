using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GeluidenController : ControllerBase
    {
        private readonly GeluidenService _service;

        public GeluidenController(GeluidenService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleGeluidenOp()
        {
            var Geluiden = _service.HaalAlleGeluidenOp();
            return Ok(Geluiden);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegGeluidToe([FromBody] Geluiden Geluid)
        {
            if (Geluid == null)
            {
                return BadRequest("Geluid mag niet null zijn.");
            }

            _service.RegistreerGeluid(Geluid);
            return Ok("Geluid toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderGeluid(String naam)
        {
            var isVerwijderd = _service.VerwijderGeluid(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Geluid met naam {naam} niet gevonden.");
            }

            return Ok($"Geluid met naam {naam} is verwijderd.");
        }
    }
}
