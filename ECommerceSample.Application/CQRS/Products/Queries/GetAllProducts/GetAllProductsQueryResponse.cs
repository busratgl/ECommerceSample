namespace ECommerceSample.Application.CQRS.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}