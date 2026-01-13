using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Shared.DTOs.Instructeur;
using Rijschool.Shared.DTOs.Rijles;
using Rijschool.Shared.DTOs.Examen;
using Rijschool.Shared.DTOs.Ziekmelding;
using Rijschool.Applicatie.Repositories;
using Rijschool.Applicatie.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructeurController : ControllerBase
    {

        private readonly IInstructeurRepository _instructeurRepository;
        private readonly IRijlesRepository _rijlesRepository;
        private readonly IExamenRepository _examenRepository;
        private readonly IZiekmeldingRepository _ziekmeldingRepository;

        public InstructeurController(
            IInstructeurRepository instructeurRepository,
            IRijlesRepository rijlesRepository,
            IExamenRepository examenRepository,
            IZiekmeldingRepository ziekmeldingRepository)
        {
            _instructeurRepository = instructeurRepository;
            _rijlesRepository = rijlesRepository;
            _examenRepository = examenRepository;
            _ziekmeldingRepository = ziekmeldingRepository;
        }


        // GET api/instructeur/{id}
        // Haal profielgegevens van een instructeur op
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<InstructeurDto> GetInstructeur(int id)
        {
            var instructeur = _instructeurRepository.GeefInstructeur(id);
            if (instructeur == null) return NotFound();
            return Ok(instructeur);
        }

        // PUT api/instructeur/{id}
        // Pas eigen profielgegevens aan (telefoon/email)
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateInstructeur(int id, [FromBody] UpdateInstructeurDto dto)
        {
            var success = _instructeurRepository.UpdateInstructeur(id, dto);
            if (!success) return NotFound();
            return Ok();
        }

        // GET api/instructeur/{id}/rijlessen
        // Haal alle rijlessen van deze instructeur op
        [HttpGet("{id}/rijlessen")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RijlesDto>> GetRijlessen(int id)
        {
            var lessen = _rijlesRepository.GeefAlleRijlessen();
            var instructeurLessen = lessen.Where(r => r.InstructeurNaam.Contains(_instructeurRepository.GeefInstructeur(id).Voornaam));
            return Ok(instructeurLessen);
        }

        // GET api/instructeur/{id}/examens
        // Haal alle examens van deze instructeur op
        [HttpGet("{id}/examens")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ExamenDto>> GetExamens(int id)
        {
            var examens = _examenRepository.GeefAlleExamens();
            var instructeurExamens = examens.Where(e => e.InstructeurId == id);
            return Ok(instructeurExamens);
        }

        // GET api/instructeur/{id}/ziekmeldingen
        // Haal alle ziekmeldingen van deze instructeur op
        [HttpGet("{id}/ziekmeldingen")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ZiekmeldingDto>> GetZiekmeldingen(int id)
        {
            var ziekmeldingen = _ziekmeldingRepository.GeefAlleZiekmeldingen();
            var instructeurZiek = ziekmeldingen.Where(z => z.InstructeurId == id);
            return Ok(instructeurZiek);
        }
    }
}
