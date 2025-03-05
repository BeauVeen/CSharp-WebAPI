using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SoortenController : ControllerBase
    {
        private readonly SoortService _service;

        public SoortenController(SoortService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleSoortenOp()
        {
            var Soorten = _service.HaalAlleSoortenOp();
            return Ok(Soorten);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegSoortToe([FromBody] Soorten Soort)
        {
            if (Soort == null)
            {
                return BadRequest("Soort mag niet null zijn.");
            }

            _service.RegistreerSoort(Soort);
            return Ok("Soort toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderSoort(String naam)
        {
            var isVerwijderd = _service.VerwijderSoort(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Soort met naam {naam} niet gevonden.");
            }

            return Ok($"Soort met naam {naam} is verwijderd.");
        }
    }
}
