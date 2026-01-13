using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Shared.DTOs.Leerling;
using Rijschool.Applicatie.Repositories;
using System.Collections.Generic;
using Rijschool.Shared.DTOs.Examen;
using Rijschool.Shared.DTOs.Rijles;
using Rijschool.Applicatie.Interfaces;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeerlingController : ControllerBase
    {
        private readonly ILeerlingRepository _leerlingRepository;
        private readonly IRijlesRepository _rijlesRepository;
        private readonly IExamenRepository _examenRepository;


        public LeerlingController(
            ILeerlingRepository leerlingRepository,
            IRijlesRepository rijlesRepository,
            IExamenRepository examenRepository)
        {
            _leerlingRepository = leerlingRepository;
            _rijlesRepository = rijlesRepository;
            _examenRepository = examenRepository;
        }

        // GET api/leerling/{id}
        // Haal profielgegevens van een leerling op
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<LeerlingDto> GetLeerling(int id)
        {
            var leerling = _leerlingRepository.GeefLeerling(id);
            if (leerling == null) return NotFound();
            return Ok(leerling);
        }

        // PUT api/leerling/{id}
        // Leerling past eigen profielgegevens aan (telefoon, email, adres)
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateLeerling(int id, [FromBody] UpdateLeerlingDto dto)
        {
            var success = _leerlingRepository.UpdateLeerling(id, dto);
            if (!success) return NotFound();
            return Ok();
        }

        // GET api/leerling/{id}/rijlessen
        // Haal alle rijlessen van deze leerling op
        [HttpGet("{id}/rijlessen")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RijlesDto>> GetRijlessen(int id)
        {
            var lessen = _rijlesRepository.GeefAlleRijlessen();
            var leerlingLessen = lessen.Where(r => r.LeerlingNaam.Contains(_leerlingRepository.GeefLeerling(id).Voornaam));
            return Ok(leerlingLessen);
        }

        // GET api/leerling/{id}/examens
        // Haal alle examens van deze leerling op
        [HttpGet("{id}/examens")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ExamenDto>> GetExamens(int id)
        {
            var examens = _examenRepository.GeefAlleExamens();
            var leerlingExamens = examens.Where(e => e.LeerlingId == id);
            return Ok(leerlingExamens);
        }
    }
}
