using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Application.Contract.Persistences;

public interface ITamanoRepository
{
    public Task<IEnumerable<DtoCatTamano>> CatTamaño();
}
