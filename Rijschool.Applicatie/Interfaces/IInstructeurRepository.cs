using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rijschool.Shared.DTOs.Instructeur;

namespace Rijschool.Applicatie.Interfaces
{
    public interface IInstructeurRepository
    {
        IEnumerable<InstructeurDto> GeefAlleInstructeurs();
        InstructeurDto GeefInstructeur(int id);
        bool UpdateInstructeur(int id, UpdateInstructeurDto dto);
    }
}
