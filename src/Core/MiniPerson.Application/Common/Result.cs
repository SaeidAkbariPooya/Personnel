namespace MiniPerson.Application.Common;

public class Result
{
    public bool Succeeded { get; set; }
    public string ErrorMessage { get; set; }

    public static Result Successfull() => new() { Succeeded = true };

    public static Result<TData> Successfull<TData>(TData data)
    {
        return new Result<TData>
        {
            Succeeded = true,
            Data = data
        };
    }

    public static Result Failed(string errorMessage) => new() { ErrorMessage = errorMessage };

    public static Result<TData> Failed<TData>(string errorMessage)
    {
        return new Result<TData>
        {
            Succeeded = false,
            ErrorMessage = errorMessage
        };
    }
}

public class Result<TData>
{
    public TData Data { get; set; }
    public bool Succeeded { get; set; }
    public string ErrorMessage { get; set; }
}
