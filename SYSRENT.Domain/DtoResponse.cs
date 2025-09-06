namespace SYSRENT.Domain;

public sealed class DtoResponse<T>
{
    public bool Status { get; set; }
    public T? Value { get; set; }
    public string? Msg { get; set; } = string.Empty;
}
