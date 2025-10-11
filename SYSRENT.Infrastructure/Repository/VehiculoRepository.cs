using System.Data;
using Dapper;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Infrastructure.Repository;

public class VehiculoRepository(ISqlDbConnection sqlDbConnection) : IVehiculoRepository
{
    public async Task<bool> AgregarVehiculo(VEHICULO Vehiculo)
    {
        bool Result = true;

        try
        {
            const string SQLScript = @"INSERT INTO VEHICULO(Descrip, IdTamaño,Capacidad, PRenta)
                                                      VALUE(@P_Descrip, @P_IdTamaño, @P_Capacidad, @P_PRenta)";

            var dpParametros = new
            {
                P_Descrip = Vehiculo.Descrip,
                P_IdTamaño = Vehiculo.IdTamaño,
                P_Capacidad = Vehiculo.Capacidad,
                P_PRenta = Vehiculo.PRenta
            };
            
            using var Conn = sqlDbConnection.GetConnection();

            var rows = await Conn.ExecuteAsync(SQLScript, dpParametros, commandType: CommandType.Text);

            if (rows <= 0) Result = false;

        }
        catch
        {
            Result = false;
        }

        return Result;
    }
}
