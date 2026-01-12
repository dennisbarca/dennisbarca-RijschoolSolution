using Rijschool.Applicatie.DTOs.Leerling;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.WebAPI.Repositories
{
    public class LeerlingRepository
    {
        // Dummy data voor testen
        private readonly List<LeerlingDto> _leerlingen = new List<LeerlingDto>
        {
            new LeerlingDto { Id = 1, Voornaam = "Jan", Achternaam = "Jansen", Telefoonnummer = "0612345678", Email = "jan@rijschool.nl", Adres = "Straat 1" },
            new LeerlingDto { Id = 2, Voornaam = "Piet", Achternaam = "Pietersen", Telefoonnummer = "0698765432", Email = "piet@rijschool.nl", Adres = "Straat 2" }
        };

        // GET alle leerlingen
        public IEnumerable<LeerlingDto> GeefAlleLeerlingen() => _leerlingen;

        // GET één leerling op id
        public LeerlingDto GeefLeerling(int id) => _leerlingen.FirstOrDefault(l => l.Id == id);

        // PUT / update profiel (telefoonnummer, email, adres)
        public bool UpdateLeerling(int id, UpdateLeerlingDto dto)
        {
            var leerling = _leerlingen.FirstOrDefault(l => l.Id == id);
            if (leerling == null) return false;

            if (!string.IsNullOrEmpty(dto.Telefoonnummer)) leerling.Telefoonnummer = dto.Telefoonnummer;
            if (!string.IsNullOrEmpty(dto.Email)) leerling.Email = dto.Email;
            if (!string.IsNullOrEmpty(dto.Adres)) leerling.Adres = dto.Adres;

            return true;
        }
    }
}
