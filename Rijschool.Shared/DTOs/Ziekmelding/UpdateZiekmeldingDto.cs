using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rijschool.Shared.DTOs.Ziekmelding
{
    public class UpdateZiekmeldingDto
    {
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
