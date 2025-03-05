using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WeblinksController : ControllerBase
    {
        private readonly WeblinkService _service;

        public WeblinksController(WeblinkService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleWeblinksOp()
        {
            var Weblinks = _service.HaalAlleWeblinksOp();
            return Ok(Weblinks);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegWeblinkToe([FromBody] Weblinks Weblink)
        {
            if (Weblink == null)
            {
                return BadRequest("Weblink mag niet null zijn.");
            }

            _service.RegistreerWeblink(Weblink);
            return Ok("Weblink toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderWeblink(String naam)
        {
            var isVerwijderd = _service.VerwijderWeblink(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Weblink met naam {naam} niet gevonden.");
            }

            return Ok($"Weblink met naam {naam} is verwijderd.");
        }
    }
}
