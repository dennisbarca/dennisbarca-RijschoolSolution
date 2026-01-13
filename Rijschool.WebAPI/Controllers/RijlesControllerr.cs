using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Shared.DTOs.Rijles;
using Rijschool.Applicatie.Repositories;
using System.Collections.Generic;
using System.Linq;
using Rijschool.Applicatie.Interfaces;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RijlesController : ControllerBase
    {
        private readonly IRijlesRepository _rijlesRepository;

        public RijlesController(IRijlesRepository rijlesRepository)
        {
            _rijlesRepository = rijlesRepository;
        }

        // GET api/rijles
        // Haal alle rijlessen op
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RijlesDto>> GetAlleRijlessen()
        {
            var lessen = _rijlesRepository.GeefAlleRijlessen();
            return Ok(lessen);
        }

        // GET api/rijles/leerling/{id}
        // Haal alle rijlessen van een specifieke leerling op
        [HttpGet("leerling/{leerlingId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RijlesDto>> GetRijlessenVanLeerling(int leerlingId)
        {
            var lessen = _rijlesRepository.GeefAlleRijlessen();
            var leerlingLessen = lessen.Where(r => r.LeerlingId == leerlingId);
            return Ok(leerlingLessen);
        }

        // GET api/rijles/instructeur/{id}
        // Haal alle rijlessen van een specifieke instructeur op
        [HttpGet("instructeur/{instructeurId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RijlesDto>> GetRijlessenVanInstructeur(int instructeurId)
        {
            var lessen = _rijlesRepository.GeefAlleRijlessen();
            var instructeurLessen = lessen.Where(r => r.InstructeurId == instructeurId);
            return Ok(instructeurLessen);
        }

        // GET api/rijles/{id}
        // Haal één rijles op basis van id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RijlesDto> GetRijles(int id)
        {
            var les = _rijlesRepository.GeefRijles(id);
            if (les == null) return NotFound();
            return Ok(les);
        }

        // PUT api/rijles/{id}/ophaaladres
        // Leerling past ophaaladres aan
        [HttpPut("{id}/ophaaladres")]
        [AllowAnonymous]
        public ActionResult WijzigOphaaladres(int id, [FromBody] string nieuwAdres)
        {
            var success = _rijlesRepository.WijzigOphaaladres(id, nieuwAdres);
            if (!success) return NotFound("Rijles niet gevonden");
            return Ok();
        }

        // PUT api/rijles/{id}/annuleren
        // Leerling annuleert les > 24 uur van tevoren
        [HttpPut("{id}/annuleren")]
        [AllowAnonymous]
        public ActionResult AnnuleerRijles(int id)
        {
            var success = _rijlesRepository.AnnuleerRijles(id);
            if (!success) return BadRequest("Les kan niet worden geannuleerd (minder dan 24 uur).");
            return Ok();
        }

        // PUT api/rijles/{id}/commentaar
        // Instructeur voegt commentaar toe
        [HttpPut("{id}/commentaar")]
        [AllowAnonymous]
        public ActionResult VoegCommentaarToe(int id, [FromBody] string commentaar)
        {
            var success = _rijlesRepository.VoegCommentaarToe(id, commentaar);
            if (!success) return NotFound("Rijles niet gevonden");
            return Ok();
        }

        // POST api/rijles
        // Instructeur plant een nieuwe rijles
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<RijlesDto> PlanRijles([FromBody] CreateRijlesDto dto)
        {
            // Voorbeeld: In de echte app haal je de IDs uit de database
            int leerlingId = 1;   // tijdelijke dummy
            int instructeurId = 1; // tijdelijke dummy

            var nieuweLes = _rijlesRepository.PlanRijles(dto, leerlingId, instructeurId);
            return Ok(nieuweLes);
        }
    }
}
