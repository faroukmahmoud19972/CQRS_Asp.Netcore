using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Query
{
    public class GetCategoryDetailsHandler : IRequestHandler<GetCategoryDetailsRequest, CategoryDTO>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryDetailsHandler(ICategoryRepository repository , IMapper mapper)
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
