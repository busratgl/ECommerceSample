namespace ECommerceSample.Application.Requests.Orders;

public class CreateOrderRequest
{
    public string Description { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }
}