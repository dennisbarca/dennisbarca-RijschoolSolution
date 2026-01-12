using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Applicatie.DTOs.Examen
{
    public class ExamenDto
    {
        public int Id { get; set; }          
        public DateTime Datum { get; set; }
        public string Type { get; set; }     
        public string Resultaat { get; set; } 
        public int LeerlingId { get; set; }  
        public int InstructeurId { get; set; } 
    }
}
