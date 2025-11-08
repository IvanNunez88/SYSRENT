using SYSRENT.Domain.Vehiculo.DTO;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Contract.Persistences;

public interface IVehiculoRepository
{
    public Task<bool> AgregarVehiculo(VEHICULO Vehiculo);
    public Task<bool> ActualizarVehiculo(UPDVEHICULO Vehiculo);
    public Task<IEnumerable<DtoConsultaVehiculo>> ConsultaVehiculo();

}
