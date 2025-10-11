using System.Data;
using Dapper;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Infrastructure.Repository;

public class TamanoRepository(ISqlDbConnection sqlDbConnection) : ITamanoRepository
{

    private static readonly string DefaultCatalog = "[SELECCIONAR]";
    public async Task<IEnumerable<DtoCatTamano>> CatTamaño()
    {
        List<DtoCatTamano> lstDatos = [new DtoCatTamano(IdTamaño: 0, Descrip: DefaultCatalog)];

        const string SQLScript = @"SELECT IdTamaño,
                                          Descrip
                                   FROM TAMAÑO";

        using var Conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoCatTamano> enuDatos = await Conn.QueryAsync<DtoCatTamano>(SQLScript, null, commandType: CommandType.Text);

        lstDatos.AddRange(enuDatos);

        return lstDatos;
    }
}
