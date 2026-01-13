using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rijschool.Shared.DTOs.Rijles;

namespace Rijschool.Applicatie.Interfaces
{
    public interface IRijlesRepository
    {
        IEnumerable<RijlesDto> GeefAlleRijlessen();
        IEnumerable<RijlesDto> GeefRijlessenVoorLeerling(int leerlingId);
        RijlesDto GeefRijles(int id);
        RijlesDto PlanRijles(CreateRijlesDto dto, int leerlingId, int instructeurId);
        bool WijzigOphaaladres(int id, string nieuwAdres);
        bool AnnuleerRijles(int id);
        bool VoegCommentaarToe(int id, string commentaar);
    }
}
