using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}