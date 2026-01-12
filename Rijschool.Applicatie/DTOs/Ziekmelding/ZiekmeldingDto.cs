using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Applicatie.DTOs.Ziekmelding
{
    public class ZiekmeldingDto
    {
        public int Id { get; set; }           // ZiekmeldingId
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int InstructeurId { get; set; } // koppeling naar instructeur
    }
}
