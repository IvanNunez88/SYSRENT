using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Contract.Persistences;

public interface IVehiculoRepository
{
    public Task<bool> AgregarVehiculo(VEHICULO Vehiculo);
}
