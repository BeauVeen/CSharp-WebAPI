using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GeluidWaarnemingController : ControllerBase
    {
        private readonly GeluidWaarnemingService _service;

        public GeluidWaarnemingController(GeluidWaarnemingService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleGeluidWaarnemingenOp()
        {
            var geluidWaarneming = _service.HaalAlleGeluidWaarnemingenOp();
            return Ok(geluidWaarneming);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegGeluidWaarnemingToe([FromBody] GeluidWaarneming geluidWaarneming)
        {
            if (geluidWaarneming == null)
            {
                return BadRequest("Geluid waarneming mag niet null zijn.");
            }

            _service.RegistreerGeluidWaarneming(geluidWaarneming);
            return Ok("Geluid waarneming toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderGeluidWaarneming(String naam)
        {
            var isVerwijderd = _service.VerwijderGeluidWaarneming(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Geluid waarneming met naam {naam} niet gevonden.");
            }

            return Ok($"Geluid waarneming met naam {naam} is verwijderd.");
        }
    }
}
