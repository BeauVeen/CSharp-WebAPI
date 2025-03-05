using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FotoWaarnemingController : ControllerBase
    {
        private readonly FotoWaarnemingService _service;

        public FotoWaarnemingController(FotoWaarnemingService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleFotoWaarnemingenOp()
        {
            var fotoWaarneming = _service.HaalAlleFotoWaarnemingenOp();
            return Ok(fotoWaarneming);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegfotoWaarnemingToe([FromBody] FotoWaarneming fotoWaarneming)
        {
            if (fotoWaarneming == null)
            {
                return BadRequest("Foto waarneming mag niet null zijn.");
            }

            _service.RegistreerFotoWaarneming(fotoWaarneming);
            return Ok("Foto waarneming toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderfotoWaarneming(String naam)
        {
            var isVerwijderd = _service.VerwijderFotoWaarneming(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Foto waarneming met naam {naam} niet gevonden.");
            }

            return Ok($"Foto waarneming met naam {naam} is verwijderd.");
        }
    }
}
