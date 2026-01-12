using Rijschool.Applicatie.DTOs.Ziekmelding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.WebAPI.Repositories
{
    public class ZiekmeldingRepository
    {
        // Dummy data voor testen
        private readonly List<ZiekmeldingDto> _ziekmeldingen = new List<ZiekmeldingDto>
        {
            new ZiekmeldingDto { Id = 1, StartDatum = DateTime.Today.AddDays(1), EindDatum = DateTime.Today.AddDays(3), InstructeurId = 1 },
            new ZiekmeldingDto { Id = 2, StartDatum = DateTime.Today.AddDays(5), EindDatum = DateTime.Today.AddDays(6), InstructeurId = 2 }
        };

        // GET alle ziekmeldingen
        public IEnumerable<ZiekmeldingDto> GeefAlleZiekmeldingen() => _ziekmeldingen;

        // GET één ziekmelding op id
        public ZiekmeldingDto GeefZiekmelding(int id) => _ziekmeldingen.FirstOrDefault(z => z.Id == id);

        // POST - voeg nieuwe ziekmelding toe
        public ZiekmeldingDto VoegZiekmeldingToe(CreateZiekmeldingDto dto)
        {
            var ziekmelding = new ZiekmeldingDto
            {
                Id = _ziekmeldingen.Count + 1,
                StartDatum = dto.StartDatum,
                EindDatum = dto.EindDatum,
                InstructeurId = dto.InstructeurId
            };
            _ziekmeldingen.Add(ziekmelding);
            return ziekmelding;
        }

        // PUT - update ziekmelding
        public bool UpdateZiekmelding(int id, UpdateZiekmeldingDto dto)
        {
            var ziekmelding = _ziekmeldingen.FirstOrDefault(z => z.Id == id);
            if (ziekmelding == null) return false;

            ziekmelding.StartDatum = dto.StartDatum;
            ziekmelding.EindDatum = dto.EindDatum;
            return true;
        }
    }
}
