using System.Data.Common;
using MediatR;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Domain;
using SYSRENT.Domain.Tamano.DTO;

namespace SYSRENT.Application.Features.Tamano.Query;

#region Query

public record GetCatTamanoQuery : IRequest<DtoResponse<IEnumerable<DtoCatTamano>>>;

#endregion

#region Handler

public class GetCatTamanoQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCatTamanoQuery, DtoResponse<IEnumerable<DtoCatTamano>>>
{
    public async Task<DtoResponse<IEnumerable<DtoCatTamano>>> Handle(GetCatTamanoQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DtoCatTamano> enuDatos = await _unitOfWork.TamanoRepository.CatTamaño();
        DtoResponse<IEnumerable<DtoCatTamano>> rsp = new();

        if (enuDatos.Any())
        {
            rsp.Status = true;
            rsp.Value = enuDatos;
        }
        else
        {
            rsp.Status = false;
            rsp.Msg = "No se encontraron registros";
        }

        return rsp;
    }
}

#endregion


