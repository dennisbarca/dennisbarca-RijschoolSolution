using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Applicatie.DTOs.Leerling
{
    public class UpdateLeerlingDto
    {
        public string Telefoonnummer { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}

