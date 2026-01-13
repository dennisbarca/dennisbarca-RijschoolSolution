using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rijschool.Shared.DTOs.Ziekmelding;

namespace Rijschool.Applicatie.Interfaces
{
    public interface IZiekmeldingRepository
    {
        IEnumerable<ZiekmeldingDto> GeefAlleZiekmeldingen();
        ZiekmeldingDto GeefZiekmelding(int id);
        ZiekmeldingDto VoegZiekmeldingToe(CreateZiekmeldingDto dto);
        bool UpdateZiekmelding(int id, UpdateZiekmeldingDto dto);

        IEnumerable<ZiekmeldingDto> GeefZiekmeldingenVoorInstructeur(int instructeurId);
    }
}
