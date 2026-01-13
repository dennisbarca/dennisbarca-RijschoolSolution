using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Shared.DTOs.Examen;
using Rijschool.Applicatie.Repositories;
using System.Collections.Generic;
using Rijschool.Applicatie.Interfaces;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamenController : ControllerBase
    {
        private readonly IExamenRepository _repository;

        public ExamenController(IExamenRepository repository)
        {
            _repository = repository;
        }


        // GET api/examen
        // Haal alle examens op
        [HttpGet]
        public ActionResult<IEnumerable<ExamenDto>> GetExamens()
        {
            var examens = _repository.GeefAlleExamens();
            return Ok(examens);
        }

        // GET api/examen/{id}
        // Haal één examen op basis van id
        [HttpGet("{id}")]
        public ActionResult<ExamenDto> GetExamen(int id)
        {
            var examen = _repository.GeefExamen(id);
            if (examen == null) return NotFound();
            return Ok(examen);
        }

        // POST api/examen
        // Plan een nieuw examen (alleen instructeur)
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ExamenDto> PlanExamen(CreateExamenDto dto)
        {
            var examen = _repository.PlanExamen(dto);
            return Ok(examen);
        }

        // PUT api/examen/{id}/resultaat
        // Update het resultaat van een examen (alleen instructeur)
        [HttpPut("{id}/resultaat")]
        [AllowAnonymous]
        public ActionResult UpdateResultaat(int id, UpdateExamenDto dto)
        {
            var success = _repository.UpdateExamenResultaat(id, dto);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
