namespace ECommerceSample.Application.Responses.Base;

public class Result<T> : IResult<T>
{
    public Result(ResultStatus resultStatus, T data)
    {
        ResultStatus = resultStatus;
        Data = data;
    }

    public Result(ResultStatus resultStatus, string message)
    {
        ResultStatus = resultStatus;
        Message = message;
    }

    public Result(ResultStatus resultStatus, string message, T data)
    {
        ResultStatus = resultStatus;
        Message = message;
        Data = data;
    }


    public T Data { get; }
    public ResultStatus ResultStatus { get; }
    public string Message { get; }
}