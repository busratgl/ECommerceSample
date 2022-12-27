namespace ECommerceSample.Application.Requests.BasketItems;

public class UpdateBasketItemRequest
{
    public long ProductId { get; set; }
    public long BasketId { get; set; }
}