using Ecommerce.Application.Features.Categories.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var oldCategory = await _repository.GetAsync(request.id);
            await _repository.DeleteAsync(oldCategory.id);

            return Unit.Value;

        }
    }
}
