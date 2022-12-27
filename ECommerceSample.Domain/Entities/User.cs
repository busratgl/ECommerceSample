using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public DateTime BirthDate { get; set; }
    public string PasswordText { get; set; }
    public decimal Balance { get; set; }
    public ICollection<Order> Orders { get; set; }
    public Basket Basket { get; set; }
}