using Catalog.Application.Reponses; 
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllTypesQuery : IRequest<IList<TypesReponse>>
    {
    }
}
