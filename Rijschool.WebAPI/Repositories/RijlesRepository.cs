using Rijschool.Applicatie.DTOs.Rijles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.WebAPI.Repositories
{
    public class RijlesRepository
    {
        // Dummy data voor testen
        private readonly List<RijlesDto> _rijlessen = new List<RijlesDto>
        {
            new RijlesDto
            {
                Id = 1,
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
    }
}
