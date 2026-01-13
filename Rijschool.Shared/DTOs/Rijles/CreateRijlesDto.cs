using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Shared.DTOs.Rijles
{
    public class CreateRijlesDto
    {
        public string LeerlingNaam { get; set; }
        public string InstructeurNaam { get; set; }
        public DateTime Datum { get; set; }
        public string StartTijd { get; set; }
        public string EindTijd { get; set; }
        public string Ophaaladres { get; set; }
        public string Lesdoel { get; set; }
    }
}
