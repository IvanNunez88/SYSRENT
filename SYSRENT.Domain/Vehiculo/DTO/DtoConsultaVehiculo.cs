namespace SYSRENT.Domain.Vehiculo.DTO;

public sealed record DtoConsultaVehiculo
(
    byte IdVehiculo,
    string Vehiculo,
    byte IdTamaño,
    string Tamano,
    byte Capacidad,
    decimal PRenta,
    bool IsActivo,
    string Estatus
);

