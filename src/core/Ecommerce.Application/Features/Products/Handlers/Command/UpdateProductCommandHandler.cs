using Ecommerce.Application.DTOs.EntitiesDTO.Category.Validators;
using Ecommerce.Application.DTOs.EntitiesDTO.Product.Validator;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Features.Products.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var validator = new ProductValidators(_repository);
            var validatorResult = await validator.ValidateAsync(request.ProductDTO, cancellationToken);
            if (validatorResult.IsValid==false)
                throw new ValidationExceptions(validatorResult);

            var oldproduct = await _repository.GetAsync(request.ProductDTO.id);
            var res = _mapper.Map(request.ProductDTO, oldproduct);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
