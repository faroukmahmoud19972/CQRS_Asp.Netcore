using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Products.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var oldPorduct = await _repository.GetAsync(request.id);

            if (oldPorduct == null)
                throw new NotFoundException(nameof(Product), request.id);

            await _repository.DeleteAsync(oldPorduct.Id);

            return Unit.Value;

        }
    }
}
