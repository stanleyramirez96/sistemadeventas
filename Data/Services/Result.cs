﻿namespace sistemadeventas.Data.Services;

public class Result
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
public class Result<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}

