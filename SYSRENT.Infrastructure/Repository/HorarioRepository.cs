using System.Data;
using Dapper;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Application.Data;
using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Infrastructure.Repository;

public class HorarioRepository(ISqlDbConnection sqlDbConnection) : IHorarioRepository
{
    private static readonly string DefaultCatalog = "[SELECCIONAR]";
    public async Task<IEnumerable<DtoConsulCatHorario>> ConsultaCatHorario()
    {
        List<DtoConsulCatHorario> lstDatos = [new DtoConsulCatHorario(IdHorario: 0, Descrip: DefaultCatalog, Minutos: 0)];

        const string SQLScript = @"SELECT IdHorario,
                                        Descrip,
                                        Minutos
                                    FROM HORARIO";

        using var Conn = sqlDbConnection.GetConnection();

        IEnumerable<DtoConsulCatHorario> enuDatos = await Conn.QueryAsync<DtoConsulCatHorario>(SQLScript, null, commandType: CommandType.Text);

        lstDatos.AddRange(enuDatos);

        return lstDatos;
    }
}
