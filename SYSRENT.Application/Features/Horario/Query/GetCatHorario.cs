using MediatR;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Domain;
using SYSRENT.Domain.Horario.DTO;

namespace SYSRENT.Application.Features.Horario.Query;

#region Query
public record GetCatHorarioQuery : IRequest<DtoResponse<IEnumerable<DtoConsulCatHorario>>>;
#endregion

#region Handler
public class GetCatHorarioQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCatHorarioQuery, DtoResponse<IEnumerable<DtoConsulCatHorario>>>
{
    public async Task<DtoResponse<IEnumerable<DtoConsulCatHorario>>> Handle(GetCatHorarioQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DtoConsulCatHorario> enuDatos = await _unitOfWork.HorarioRepository.ConsultaCatHorario();
        DtoResponse<IEnumerable<DtoConsulCatHorario>> rsp = new();

        if (enuDatos.Any())
        {
            rsp.Status = true;
            rsp.Value = enuDatos;
        }
        else
        {
            rsp.Status = false;
            rsp.Msg = "No se encontro Información";
        }

        return rsp;
    }
}
#endregion