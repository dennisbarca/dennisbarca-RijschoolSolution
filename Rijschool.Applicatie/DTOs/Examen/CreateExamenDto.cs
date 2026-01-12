using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Applicatie.DTOs.Examen
{
    public class CreateExamenDto
    {
        public DateTime Datum { get; set; }
        public string Type { get; set; }      
        public int LeerlingId { get; set; }
        public int InstructeurId { get; set; }
    }
}
