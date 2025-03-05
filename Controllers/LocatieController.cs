using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LocatiesController : ControllerBase
    {
        private readonly LocatieService _service;

        public LocatiesController(LocatieService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleLocatiesOp()
        {
            var Locaties = _service.HaalAlleLocatiesOp();
            return Ok(Locaties);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegLocatieToe([FromBody] Locatie Locatie)
        {
            if (Locatie == null)
            {
                return BadRequest("Locatie mag niet null zijn.");
            }

            _service.RegistreerLocatie(Locatie);
            return Ok("Locatie toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderLocatie(String naam)
        {
            var isVerwijderd = _service.VerwijderLocatie(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Locatie met naam {naam} niet gevonden.");
            }

            return Ok($"Locatie met naam {naam} is verwijderd.");
        }
    }
}
