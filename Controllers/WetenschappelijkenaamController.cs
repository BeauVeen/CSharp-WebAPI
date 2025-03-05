using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WetenschappelijkenamenController : ControllerBase
    {
        private readonly WetenschappelijkenaamService _service;

        public WetenschappelijkenamenController(WetenschappelijkenaamService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleWetenschappelijkenamenOp()
        {
            var Wetenschappelijkenamen = _service.HaalAlleWetenschappelijkenamenOp();
            return Ok(Wetenschappelijkenamen);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegWetenschappelijkenaamToe([FromBody] Wetenschappelijkenaam wetenschappelijkeNaam)
        {
            if (wetenschappelijkeNaam == null)
            {
                return BadRequest("Wetenschappelijke naam mag niet null zijn.");
            }

            _service.RegistreerWetenschappelijkenaam(wetenschappelijkeNaam);
            return Ok("Wetenschappelijke naam toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderWetenschappelijkenaam(String naam)
        {
            var isVerwijderd = _service.VerwijderWetenschappelijkenaam(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Wetenschappelijke naam met naam {naam} niet gevonden.");
            }

            return Ok($"Wetenschappelijke naam met naam {naam} is verwijderd.");
        }
    }
}
