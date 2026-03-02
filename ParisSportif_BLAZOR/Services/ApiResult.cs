using System;

namespace ParisSportif_BLAZOR.Services;

public class ApiResult<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
}
