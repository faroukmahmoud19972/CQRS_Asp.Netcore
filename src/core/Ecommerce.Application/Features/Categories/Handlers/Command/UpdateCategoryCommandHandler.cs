using Ecommerce.Application.DTOs.EntitiesDTO.Category.Validators;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Categories.Requests.Command;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validators = new CategoryValidator();
            var validatorResult = await validators.ValidateAsync(request.CategoryDTO);
            if (validatorResult.IsValid == false)
                throw new ValidationExceptions(validatorResult);

            var oldCategory = await _repository.GetAsync(request.CategoryDTO.id);
            var res = _mapper.Map(request.CategoryDTO,oldCategory);
             await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
