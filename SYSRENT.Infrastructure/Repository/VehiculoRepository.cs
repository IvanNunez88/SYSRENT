using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Vehiculo.DTO;
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
                                                      VALUES (@P_Descrip, @P_IdTamaño, @P_Capacidad, @P_PRenta)";
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
        catch(SqlException e)
        {
            Result = false;
        }

        return Result;
    }

    public async Task<IEnumerable<DtoConsultaVehiculo>> ConsultaVehiculo()
    {
        const string SQLScript = @"SELECT VEH.IdVehiculo,
                                        UPPER(VEH.Descrip) AS Vehiculo,
                                        VEH.IdTamaño,
                                        TAM.Tamaño AS Tamano,
                                        VEH.Capacidad,
                                        VEH.PRenta,
                                        VEH.IsActivo,
                                        IIF(VEH.IsActivo = 1, 'ACTIVO', 'INACTIVO') AS Estatus
                                    FROM VEHICULO AS VEH
                                        INNER JOIN (SELECT IdTamaño,
                                                        UPPER(Descrip) AS [Tamaño]
                                                    FROM TAMAÑO) AS TAM ON VEH.IdTamaño = TAM.IdTamaño";

        using var Conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoConsultaVehiculo> enuDatos = (await Conn.QueryAsync<DtoConsultaVehiculo>(SQLScript, commandType: CommandType.Text)).OrderBy(x => x.Vehiculo);

        return enuDatos;
    }

}
