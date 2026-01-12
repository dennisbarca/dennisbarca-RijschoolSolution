using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Applicatie.DTOs.Rijles;
using Rijschool.WebAPI.Repositories;
using System.Collections.Generic;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RijlesController : ControllerBase
    {
        private readonly RijlesRepository _repository;

        public RijlesController(RijlesRepository repository)
        {
            _repository = repository;
        }

        // GET api/rijles
        // Haal alle rijlessen op
        [HttpGet]
        public ActionResult<IEnumerable<RijlesDto>> GetRijlessen()
        {
            var lessen = _repository.GeefAlleRijlessen();
            return Ok(lessen);
        }

        // GET api/rijles/{id}
        // Haal één rijles op basis van id
        [HttpGet("{id}")]
        public ActionResult<RijlesDto> GetRijles(int id)
        {
            var les = _repository.GeefRijles(id);
            if (les == null) return NotFound();
            return Ok(les);
        }

        // PUT api/rijles/{id}/ophaaladres
        // Leerling past ophaaladres aan
        [HttpPut("{id}/ophaaladres")]
        [Authorize(Roles = "Leerling")]
        public ActionResult WijzigOphaaladres(int id, [FromBody] string nieuwAdres)
        {
            var success = _repository.WijzigOphaaladres(id, nieuwAdres);
            if (!success) return NotFound();
            return Ok();
        }

        // PUT api/rijles/{id}/annuleren
        // Leerling annuleert les > 24 uur van tevoren
        [HttpPut("{id}/annuleren")]
        [Authorize(Roles = "Leerling")]
        public ActionResult AnnuleerRijles(int id)
        {
            var success = _repository.AnnuleerRijles(id);
            if (!success) return BadRequest("Les kan niet worden geannuleerd (minder dan 24 uur).");
            return Ok();
        }

        // PUT api/rijles/{id}/commentaar
        // Instructeur voegt commentaar toe
        [HttpPut("{id}/commentaar")]
        [Authorize(Roles = "Instructeur")]
        public ActionResult VoegCommentaarToe(int id, [FromBody] string commentaar)
        {
            var success = _repository.VoegCommentaarToe(id, commentaar);
            if (!success) return NotFound();
            return Ok();
        }

        // TODO: later optie voor instructeur om nieuwe les in te plannen
        // POST api/rijles
        [HttpPost]
        [Authorize(Roles = "Instructeur")]
        public ActionResult<RijlesDto> PlanRijles([FromBody] RijlesDto dto)
        {
            // Voor nu dummy toevoegen aan repository (kan later method in repository maken)
            return Ok(dto); // placeholder
        }
    }
}
