using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;

namespace SYSRENT.Infrastructure.Repository;

public class UnitOfWork(ISqlDbConnection _sqlDbConnection) : IUnitOfWork
{
    private readonly ISqlDbConnection _sqlDbConnection = _sqlDbConnection;
    private IHorarioRepository? _horarioRepository;
    private ITamanoRepository? _tamanoRepository;

    public IHorarioRepository HorarioRepository => _horarioRepository ??= new HorarioRepository(_sqlDbConnection);
    public ITamanoRepository TamanoRepository => _tamanoRepository ??= new TamanoRepository(_sqlDbConnection);
}
