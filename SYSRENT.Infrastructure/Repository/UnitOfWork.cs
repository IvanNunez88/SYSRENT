using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;

namespace SYSRENT.Infrastructure.Repository;

public class UnitOfWork(ISqlDbConnection _sqlDbConnection) : IUnitOfWork
{
    private readonly ISqlDbConnection _sqlDbConnection = _sqlDbConnection;
    private IHorarioRepository? _horarioRepository;

    public IHorarioRepository HorarioRepository => _horarioRepository ??= new HorarioRepository(_sqlDbConnection);
}
