using Rijschool.Applicatie.Interfaces;
using Rijschool.Shared.DTOs.Rijles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.Applicatie.Repositories
{
    public class RijlesRepository: IRijlesRepository
    {
        // Dummy data voor testen
        private readonly List<RijlesDto> _rijlessen = new List<RijlesDto>
        {
            new RijlesDto
            {
                Id = 1,
                LeerlingId = 1,
                InstructeurId = 1,
                LeerlingNaam = "Jan Jansen",
                InstructeurNaam = "Klaas Klaassen",
                Datum = DateTime.Today.AddDays(2),
                StartTijd = "10:00",
                EindTijd = "11:00",
                Ophaaladres = "Straat 1",
                Lesdoel = "Basis rijden",
                Commentaar = "",
                Status = "Gepland"
            },
            new RijlesDto
            {
                Id = 2,
                LeerlingId = 2,
                InstructeurId = 2,
                LeerlingNaam = "Piet Pietersen",
                InstructeurNaam = "Marie Jansen",
                Datum = DateTime.Today.AddDays(3),
                StartTijd = "12:00",
                EindTijd = "13:00",
                Ophaaladres = "Straat 2",
                Lesdoel = "Parkeren",
                Commentaar = "",
                Status = "Gepland"
            }
        };

        public RijlesDto PlanRijles(CreateRijlesDto dto, int leerlingId, int instructeurId)
        {
            var nieuweLes = new RijlesDto
            {
                Id = _rijlessen.Count + 1, // eenvoudige ID
                LeerlingNaam = dto.LeerlingNaam,
                LeerlingId = leerlingId,
                InstructeurNaam = dto.InstructeurNaam,
                InstructeurId = instructeurId,
                Datum = dto.Datum,
                StartTijd = dto.StartTijd,
                EindTijd = dto.EindTijd,
                Ophaaladres = dto.Ophaaladres,
                Lesdoel = dto.Lesdoel,
                Commentaar = "",
                Status = "Gepland"
            };
            _rijlessen.Add(nieuweLes);
            return nieuweLes;
        }

        // GET alle rijlessen
        public IEnumerable<RijlesDto> GeefAlleRijlessen() => _rijlessen;

        // GET rijles op id
        public RijlesDto GeefRijles(int id) => _rijlessen.FirstOrDefault(r => r.Id == id);

        // PUT - wijzig ophaaladres
        public bool WijzigOphaaladres(int id, string nieuwAdres)
        {
            var rijles = _rijlessen.FirstOrDefault(r => r.Id == id);
            if (rijles == null) return false;

            rijles.Ophaaladres = nieuwAdres;
            return true;
        }

        // PUT - annuleer les (check minimaal 24 uur van tevoren)
        public bool AnnuleerRijles(int id)
        {
            var rijles = _rijlessen.FirstOrDefault(r => r.Id == id);
            if (rijles == null) return false;

            if ((rijles.Datum - DateTime.Now).TotalHours < 24)
            {
                return false; // te laat om te annuleren
            }

            rijles.Status = "Geannuleerd";
            return true;
        }

        // PUT - voeg commentaar toe (door instructeur)
        public bool VoegCommentaarToe(int id, string commentaar)
        {
            var rijles = _rijlessen.FirstOrDefault(r => r.Id == id);
            if (rijles == null) return false;

            rijles.Commentaar = commentaar;
            return true;
        }

        public IEnumerable<RijlesDto> GeefRijlessenVoorLeerling(int leerlingId)
        {
            return _rijlessen.Where(r => r.LeerlingId == leerlingId);
        }
    }
}
