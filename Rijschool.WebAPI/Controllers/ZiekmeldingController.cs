using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Shared.DTOs.Ziekmelding;
using Rijschool.Applicatie.Interfaces;
using System.Collections.Generic;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZiekmeldingController : ControllerBase
    {
        private readonly IZiekmeldingRepository _ziekmeldingRepository;

        // Constructor moet dezelfde naam hebben als de controller
        public ZiekmeldingController(IZiekmeldingRepository ziekmeldingRepository)
        {
            _ziekmeldingRepository = ziekmeldingRepository;
        }

        // GET api/ziekmelding/instructeur/{id}
        // Haal alle ziekmeldingen voor een specifieke instructeur op
        [HttpGet("instructeur/{instructeurId}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ZiekmeldingDto>> GetZiekmeldingenVoorInstructeur(int instructeurId)
        {
            var ziekmeldingen = _ziekmeldingRepository.GeefZiekmeldingenVoorInstructeur(instructeurId);
            return Ok(ziekmeldingen);
        }


        // GET api/ziekmelding
        // Haal alle ziekmeldingen op
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ZiekmeldingDto>> GetZiekmeldingen()
        {
            var ziekmeldingen = _ziekmeldingRepository.GeefAlleZiekmeldingen();
            return Ok(ziekmeldingen);
        }

        // GET api/ziekmelding/{id}
        // Haal één ziekmelding op basis van id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ZiekmeldingDto> GetZiekmelding(int id)
        {
            var ziekmelding = _ziekmeldingRepository.GeefZiekmelding(id);
            if (ziekmelding == null) return NotFound();
            return Ok(ziekmelding);
        }

        // POST api/ziekmelding
        // Voeg een nieuwe ziekmelding toe
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ZiekmeldingDto> VoegZiekmeldingToe([FromBody] CreateZiekmeldingDto dto)
        {
            var ziekmelding = _ziekmeldingRepository.VoegZiekmeldingToe(dto);
            return Ok(ziekmelding);
        }

        // PUT api/ziekmelding/{id}
        // Update een bestaande ziekmelding
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateZiekmelding(int id, [FromBody] UpdateZiekmeldingDto dto)
        {
            var success = _ziekmeldingRepository.UpdateZiekmelding(id, dto);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
