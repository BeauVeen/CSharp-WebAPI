using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GebruikersController : ControllerBase
    {
        private readonly GebruikerService _service;

        public GebruikersController(GebruikerService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleGebruikersOp()
        {
            var Gebruikers = _service.HaalAlleGebruikersOp();
            return Ok(Gebruikers);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegGebruikerToe([FromBody] Gebruiker Gebruiker)
        {
            if (Gebruiker == null)
            {
                return BadRequest("Gebruiker mag niet null zijn.");
            }

            _service.RegistreerGebruiker(Gebruiker);
            return Ok("Gebruiker toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderGebruiker(String naam)
        {
            var isVerwijderd = _service.VerwijderGebruiker(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Gebruiker met naam {naam} niet gevonden.");
            }

            return Ok($"Gebruiker met naam {naam} is verwijderd.");
        }
    }
}
