using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WaarnemingenController : ControllerBase
    {
        private readonly WaarnemingService _service;

        public WaarnemingenController(WaarnemingService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleWaarnemingenOp()
        {
            var waarnemingen = _service.HaalAlleWaarnemingenOp();
            return Ok(waarnemingen);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegWaarnemingToe([FromBody] Waarneming waarneming)
        {
            if (waarneming == null)
            {
                return BadRequest("Waarneming mag niet null zijn.");
            }

            _service.RegistreerWaarneming(waarneming);
            return Ok("Waarneming toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderWaarneming(String naam)
        {
            var isVerwijderd = _service.VerwijderWaarneming(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Waarneming met naam {naam} niet gevonden.");
            }

            return Ok($"Waarneming met naam {naam} is verwijderd.");
        }
    }
}
