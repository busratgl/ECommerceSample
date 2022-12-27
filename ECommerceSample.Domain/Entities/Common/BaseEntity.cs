namespace ECommerceSample.Domain.Entities.Common;

public class BaseEntity
{
    public long Id { get; set; } 
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }
}