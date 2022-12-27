using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class Basket : BaseEntity
{
    public User User { get; set; }
    public long UserId { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}