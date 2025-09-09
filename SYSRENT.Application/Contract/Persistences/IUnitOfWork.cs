namespace SYSRENT.Application.Contract.Persistences;

public interface IUnitOfWork
{
    IHorarioRepository HorarioRepository { get; }

}
