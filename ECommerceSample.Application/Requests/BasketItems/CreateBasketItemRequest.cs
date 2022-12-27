namespace ECommerceSample.Application.Requests.BasketItems;

public class CreateBasketItemRequest
{
    public long ProductId { get; set; }
    public long BasketId { get; set; }
}