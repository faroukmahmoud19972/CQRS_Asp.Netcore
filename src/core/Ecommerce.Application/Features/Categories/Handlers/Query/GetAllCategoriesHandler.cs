namespace Ecommerce.Application.Features.Categories.Handlers.Query
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetAllAsync();
            var res = _mapper.Map<List<CategoryDTO>>(category);
            return res;
        }
    }
}
