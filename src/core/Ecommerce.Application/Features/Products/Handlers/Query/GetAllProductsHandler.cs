
using Ecommerce.Application.DTOs.EntitiesDTO.Product;
using Ecommerce.Application.Features.Products.Requests.Query;

namespace Ecommerce.Application.Features.Products.Handlers.Query
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            var res = _mapper.Map<List<ProductDTO>>(products);
            return res;
        }

    }
}
