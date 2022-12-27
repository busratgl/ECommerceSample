using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class BasketItem : BaseEntity
{
    public Product Product { get; set; }
    public long ProductId { get; set; }
    public Basket Basket { get; set; }
    public long BasketId { get; set; }
}