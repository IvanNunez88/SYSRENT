using MediatR;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Domain;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Features.Vehiculo.Command;

#region Command

public record AddVehiculoCommand(VEHICULO Vehiculo) : IRequest<DtoResponse<IEnumerable<string>>>;

#endregion

#region Handler

public class AddVehiculoCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<AddVehiculoCommand, DtoResponse<IEnumerable<string>>>
{
    public Task<DtoResponse<IEnumerable<string>>> Handle(AddVehiculoCommand request, CancellationToken cancellationToken)
    {
        DtoResponse<IEnumerable<string>> rsp = new();



        throw new NotImplementedException();
    }
}

#endregion