using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Product Product { get; set; }
    public long ProductId { get; set; }
    public Order Order { get; set; }
    public long OrderId { get; set; }
}