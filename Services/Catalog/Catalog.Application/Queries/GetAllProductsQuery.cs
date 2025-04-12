
using Catalog.Application.Reponses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllProductsQuery :IRequest<IList<ProductResponse>>
    {
         
    } 
}
