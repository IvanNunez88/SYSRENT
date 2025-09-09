namespace SYSRENT.Domain.Horario.Entity;

public sealed record HORARIO
(
    int? IdHorario,
    string Descrip,
    int Minutos
);
