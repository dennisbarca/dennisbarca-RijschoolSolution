using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rijschool.Shared.DTOs.Examen;

namespace Rijschool.Applicatie.Interfaces
{
    public interface IExamenRepository
    {
        IEnumerable<ExamenDto> GeefAlleExamens();
        ExamenDto GeefExamen(int id);
        ExamenDto PlanExamen(CreateExamenDto dto);
        bool UpdateExamenResultaat(int id, UpdateExamenDto dto);
    }
}
