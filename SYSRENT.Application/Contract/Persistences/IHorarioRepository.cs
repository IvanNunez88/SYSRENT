using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Application.Contract.Persistences;

public interface IHorarioRepository
{
    public Task<IEnumerable<DtoConsulCatHorario>> ConsultaCatHorario();
}
