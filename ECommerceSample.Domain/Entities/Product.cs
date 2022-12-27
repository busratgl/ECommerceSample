using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public Category Category { get; set; }
    public long CategoryId { get; set; }
}