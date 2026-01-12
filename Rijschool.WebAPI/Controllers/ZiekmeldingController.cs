using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rijschool.Applicatie.DTOs.Ziekmelding;
using Rijschool.WebAPI.Repositories;
using System.Collections.Generic;

namespace Rijschool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZiekmeldingController : ControllerBase
    {
        private readonly ZiekmeldingRepository _repository;

        public ZiekmeldingController(ZiekmeldingRepository repository)
        {
            _repository = repository;
        }

        // GET api/ziekmelding
        // Haal alle ziekmeldingen op
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ZiekmeldingDto>> GetZiekmeldingen()
        {
            var ziekmeldingen = _repository.GeefAlleZiekmeldingen();
            return Ok(ziekmeldingen);
        }

        // GET api/ziekmelding/{id}
        // Haal één ziekmelding op basis van id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ZiekmeldingDto> GetZiekmelding(int id)
        {
            var ziekmelding = _repository.GeefZiekmelding(id);
            if (ziekmelding == null) return NotFound();
            return Ok(ziekmelding);
        }

        // POST api/ziekmelding
        // Voeg een nieuwe ziekmelding toe
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ZiekmeldingDto> VoegZiekmeldingToe([FromBody] CreateZiekmeldingDto dto)
        {
            var ziekmelding = _repository.VoegZiekmeldingToe(dto);
            return Ok(ziekmelding);
        }

        // PUT api/ziekmelding/{id}
        // Update een bestaande ziekmelding
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateZiekmelding(int id, [FromBody] UpdateZiekmeldingDto dto)
        {
            var success = _repository.UpdateZiekmelding(id, dto);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
