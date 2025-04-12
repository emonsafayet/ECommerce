using Catalog.Application.Queries;
using Catalog.Application.Reponses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesReponse>>
    {
         private readonly ITypesRepository _typeRepository;

        public GetAllTypesHandler(ITypesRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IList<TypesReponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _typeRepository.GetAllTypes();
            var typesResponseList = new List<TypesReponse>();
            return typesResponseList;
        }
    }
}
