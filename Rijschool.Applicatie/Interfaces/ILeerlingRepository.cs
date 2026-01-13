using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rijschool.Shared.DTOs.Leerling;

namespace Rijschool.Applicatie.Interfaces
{
    public interface ILeerlingRepository
    {
        IEnumerable<LeerlingDto> GeefAlleLeerlingen();
        LeerlingDto GeefLeerling(int id);
        bool UpdateLeerling(int id, UpdateLeerlingDto dto);
    }
}
