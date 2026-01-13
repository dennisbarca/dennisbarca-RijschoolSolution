using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Shared.DTOs.Instructeur
{
    public class InstructeurDto
    {
        public int Id { get; set; }                
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Telefoonnummer { get; set; }
        public string Email { get; set; }
    }
}