using Rijschool.Applicatie.Interfaces;
using Rijschool.Shared.DTOs.Examen;

namespace Rijschool.Applicatie.Repositories
{
    public class ExamenRepository : IExamenRepository
    {
        // Dummy data voor testen
        private readonly List<ExamenDto> _examens = new List<ExamenDto>
        {
            new ExamenDto { Id = 1, Datum = DateTime.Today.AddDays(7), Type = "Praktijk", Resultaat = "", LeerlingId = 1, InstructeurId = 1 },
            new ExamenDto { Id = 2, Datum = DateTime.Today.AddDays(14), Type = "Praktijk", Resultaat = "", LeerlingId = 2, InstructeurId = 2 }
        };

        // GET alle examens
        public IEnumerable<ExamenDto> GeefAlleExamens() => _examens;

        // GET examen op id
        public ExamenDto GeefExamen(int id) => _examens.FirstOrDefault(e => e.Id == id);

        // POST - plan een nieuw examen
        public ExamenDto PlanExamen(CreateExamenDto dto)
        {
            var examen = new ExamenDto
            {
                Id = _examens.Count + 1, // simpel ID
                Datum = dto.Datum,
                Type = dto.Type,
                Resultaat = "", // nog niet bekend
                LeerlingId = dto.LeerlingId,
                InstructeurId = dto.InstructeurId
            };
            _examens.Add(examen);
            return examen;
        }

        // PUT - update resultaat examen
        public bool UpdateExamenResultaat(int id, UpdateExamenDto dto)
        {
            var examen = _examens.FirstOrDefault(e => e.Id == id);
            if (examen == null) return false;

            examen.Resultaat = dto.Resultaat;
            return true;
        }
    }
}
