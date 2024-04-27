using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Category;

namespace Ecommerce.Application.Features.Categories.Handlers.Query
{
    public class GetProductDetailsHandler : IRequestHandler<GetCategoryDetailsRequest, CategoryDTO>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetProductDetailsHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Handle(GetCategoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var category =await _repository.GetAsync(request.id);
            if (category == null)
                throw new Exception();
           var res   = _mapper.Map<CategoryDTO>(category);
            return res; 
        }
    }
}
