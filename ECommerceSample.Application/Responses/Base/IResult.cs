namespace ECommerceSample.Application.Responses.Base;

public interface IResult<out T> 
{
    public T Data { get; }
}