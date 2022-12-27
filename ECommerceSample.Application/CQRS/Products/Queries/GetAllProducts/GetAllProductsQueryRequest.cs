using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>>
{
    //MediatR kütüphanesi sayesinde hangi sınıfın request sınıfı olduğunu ve hangi sınıfın geriye response sınıfı olarak
    //döneceğini bilebiliyoruz.
}