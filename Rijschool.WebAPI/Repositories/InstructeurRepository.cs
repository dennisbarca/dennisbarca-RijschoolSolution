using Rijschool.Applicatie.DTOs.Instructeur;
using System.Collections.Generic;
using System.Linq;

namespace Rijschool.WebAPI.Repositories
{
    public class InstructeurRepository
    {
        // Dummy data voor testen
        private readonly List<InstructeurDto> _instructeurs = new List<InstructeurDto>
        {
            new InstructeurDto { Id = 1, Voornaam = "Klaas", Achternaam = "Klaassen", Telefoonnummer = "0611122233", Email = "klaas@rijschool.nl" },
            new InstructeurDto { Id = 2, Voornaam = "Marie", Achternaam = "Jansen", Telefoonnummer = "069998877", Email = "marie@rijschool.nl" }
        };

        // GET alle instructeurs
        public IEnumerable<InstructeurDto> GeefAlleInstructeurs() => _instructeurs;

        // GET één instructeur op id
        public InstructeurDto GeefInstructeur(int id) => _instructeurs.FirstOrDefault(i => i.Id == id);

        // PUT / update profielgegevens
        public bool UpdateInstructeur(int id, UpdateInstructeurDto dto)
        {
            var instructeur = _instructeurs.FirstOrDefault(i => i.Id == id);
            if (instructeur == null) return false;

            if (!string.IsNullOrEmpty(dto.Telefoonnummer)) instructeur.Telefoonnummer = dto.Telefoonnummer;
            if (!string.IsNullOrEmpty(dto.Email)) instructeur.Email = dto.Email;

            return true;
        }
    }
}
