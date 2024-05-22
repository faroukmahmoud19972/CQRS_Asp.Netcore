using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Products.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var oldCategory = await _repository.GetAsync(request.id);

            if (oldCategory == null)
                throw new NotFoundException(nameof(Category),request.id);

            await _repository.DeleteAsync(oldCategory.Id);

            return Unit.Value;

        }
    }
}
