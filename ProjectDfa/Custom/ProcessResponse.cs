namespace ProjectDfa.Custom;

public class ProcessResponse
{
    public required string Message { get; set; }
    public required bool Result { get; set; }
}

public class ProcessResponse<T> : ProcessResponse
{
    public required T Data { get; set; }
}