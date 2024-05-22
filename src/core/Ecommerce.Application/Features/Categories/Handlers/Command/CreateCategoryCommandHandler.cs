using Ecommerce.Application.DTOs.EntitiesDTO.Category.Validators;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validators = new CategoryValidator();
            var validatorResult =await validators.ValidateAsync(request.CategoryDTO);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed While Creation";
                response.Errors= validatorResult.Errors.Select(x=>x.ErrorMessage).ToList();
            }
            var category = _mapper.Map<Category>(request.CategoryDTO);
            response.Success = false;
            response.Message = "Created Successfully";
            response.Id = category.Id;
            await _repository.SaveAsync(category);

            return response;
        }
    }
}
