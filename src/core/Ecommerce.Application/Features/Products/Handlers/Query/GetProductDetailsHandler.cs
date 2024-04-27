using Ecommerce.Application.DTOs.EntitiesDTO.Product;
using Ecommerce.Application.Features.Products.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Query
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, ProductDTO>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductDetailsHandler(IProductRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product =await _repository.GetAsync(request.id);
            if (product == null)
                throw new Exception();
           var res   = _mapper.Map<ProductDTO>(product);
            return res; 
        }
    }
}
