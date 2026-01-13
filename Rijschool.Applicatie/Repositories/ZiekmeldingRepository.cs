using Rijschool.Shared.DTOs.Ziekmelding;
using Rijschool.Applicatie.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.Applicatie.Repositories
{
    public class ZiekmeldingRepository : IZiekmeldingRepository
    {
        private readonly List<ZiekmeldingDto> _ziekmeldingen = new List<ZiekmeldingDto>
        {
            new ZiekmeldingDto { Id = 1, StartDatum = DateTime.Today.AddDays(1), EindDatum = DateTime.Today.AddDays(3), InstructeurId = 1 },
            new ZiekmeldingDto { Id = 2, StartDatum = DateTime.Today.AddDays(5), EindDatum = DateTime.Today.AddDays(6), InstructeurId = 2 }
        };

        public IEnumerable<ZiekmeldingDto> GeefAlleZiekmeldingen() => _ziekmeldingen;

        public ZiekmeldingDto GeefZiekmelding(int id) => _ziekmeldingen.FirstOrDefault(z => z.Id == id);

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

        public bool UpdateZiekmelding(int id, UpdateZiekmeldingDto dto)
        {
            var ziekmelding = _ziekmeldingen.FirstOrDefault(z => z.Id == id);
            if (ziekmelding == null) return false;

            ziekmelding.StartDatum = dto.StartDatum;
            ziekmelding.EindDatum = dto.EindDatum;
            return true;
        }

        public IEnumerable<ZiekmeldingDto> GeefZiekmeldingenVoorInstructeur(int instructeurId)
        {
            return _ziekmeldingen.Where(z => z.InstructeurId == instructeurId);
        }

    }
}
