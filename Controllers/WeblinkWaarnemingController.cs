using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WeblinkWaarnemingenController : ControllerBase
    {
        private readonly WeblinkWaarnemingService _service;

        public WeblinkWaarnemingenController(WeblinkWaarnemingService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleWeblinkWaarnemingenOp()
        {
            var weblinkWaarnemingen = _service.HaalAlleWeblinkWaarnemingenOp();
            return Ok(weblinkWaarnemingen);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegWeblinkWaarnemingToe([FromBody] WeblinkWaarneming weblinkWaarneming)
        {
            if (weblinkWaarneming == null)
            {
                return BadRequest("Weblink waarneming mag niet null zijn.");
            }

            _service.RegistreerWeblinkWaarneming(weblinkWaarneming);
            return Ok("Weblink waarneming toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderWeblinkWaarneming(String naam)
        {
            var isVerwijderd = _service.VerwijderWeblinkWaarneming(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Weblink waarneming met naam {naam} niet gevonden.");
            }

            return Ok($"Weblink waarneming met naam {naam} is verwijderd.");
        }
    }
}
