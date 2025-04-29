
using Catalog.Application.Reponses;
using Catalog.Core.Spec;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries
{
    
    public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
    {
        public CatalogSpecParams CatalogSpecParams { get; set; }
        public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
        {
            CatalogSpecParams = catalogSpecParams;
        }
    } 
}
