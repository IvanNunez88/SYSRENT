using FluentValidation;
using SYSRENT.Application.Contract.Persistences;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Features.Vehiculo.Validator;

public class VehiculoValidator : AbstractValidator<VEHICULO>
{
    private readonly IUnitOfWork _unitOfWork;
    public VehiculoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Descrip).Cascade(CascadeMode.Stop).MinimumLength(2).WithMessage("Debe escribir una descripción del vehículo.");
        RuleFor(x => x.IdTamaño).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Debe seleccionar un tamaño");

        // RuleFor(x => x.Anio)
        //     .InclusiveBetween(1886, DateTime.Now.Year).WithMessage("El año debe estar entre 1886 y el año actual.");

        // RuleFor(x => x.Precio)
        //     .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");
    }
}
