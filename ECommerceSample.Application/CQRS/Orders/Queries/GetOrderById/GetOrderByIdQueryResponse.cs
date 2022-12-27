namespace ECommerceSample.Application.CQRS.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryResponse
{
    public long Id { get; set; }
    public string Description { get; set; }
}