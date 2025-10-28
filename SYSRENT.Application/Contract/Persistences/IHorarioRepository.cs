using SYSRENT.Domain.Horario.DTO;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.Application.Contract.Persistences;

public interface IHorarioRepository
{
    public Task<bool> Agregar(HORARIO Horario);
    public Task<IEnumerable<DtoConsulCatHorario>> ConsultaCatHorario();


}
