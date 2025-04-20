using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Reponses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
         private readonly ITypesRepository _typeRepository;

        public GetAllTypesHandler(ITypesRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _typeRepository.GetAllTypes();
            var typesResponseList = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
            return typesResponseList;
        }
    }
}
