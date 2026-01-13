using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Shared.DTOs.Rijles
{
    public class UpdateRijlesDto
    {
        public string Ophaaladres { get; set; }
        public string Lesdoel { get; set; }
        public string Commentaar { get; set; }
        public string Status { get; set; }
    }
}
