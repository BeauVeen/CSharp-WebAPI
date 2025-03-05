using Microsoft.AspNetCore.Mvc;

namespace MinimalApiExample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FotosController : ControllerBase
    {
        private readonly FotosService _service;

        public FotosController(FotosService service)
        {
            _service = service;
        }
        
        // GET: api/Soorten
        [HttpGet]
        public IActionResult HaalAlleFotosOp()
        {
            var Fotos = _service.HaalAlleFotosOp();
            return Ok(Fotos);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult VoegFotoToe([FromBody] Fotos Foto)
        {
            if (Foto == null)
            {
                return BadRequest("Foto mag niet null zijn.");
            }

            _service.RegistreerFoto(Foto);
            return Ok("Foto toegevoegd.");
        }

        // DELETE: api/Soorten/{naam}
        [HttpDelete("{naam}")]
        public IActionResult VerwijderFoto(String naam)
        {
            var isVerwijderd = _service.VerwijderFoto(naam);
            if (!isVerwijderd)
            {
                return NotFound($"Foto met naam {naam} niet gevonden.");
            }

            return Ok($"Foto met naam {naam} is verwijderd.");
        }
    }
}
