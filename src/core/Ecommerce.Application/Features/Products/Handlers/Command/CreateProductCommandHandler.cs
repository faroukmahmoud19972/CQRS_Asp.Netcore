using Ecommerce.Application.DTOs.EntitiesDTO.Product.Validator;
using Ecommerce.Application.Features.Products.Requests.Command;
using Ecommerce.Application.Models.Email;
using Ecommerce.Application.Presistance.Email;
using Ecommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper, IEmailSender emailSender)
        {
            _repository = repository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Check Validator : 
            var response = new BaseCommandResponse();
            var validator = new ProductValidators(_repository);
            var validatorResult = await validator.ValidateAsync(request.ProductDTO, cancellationToken);
            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Failed While Creation";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var product = _mapper.Map<Product>(request.ProductDTO);

            response.Success = false;
            response.Message = "Created Successfully";
            response.Id = request.ProductDTO.id;

            await _repository.SaveAsync(product);


            //send email new product :
            try
            {
                var email = new EmailMessage
                {
                    To = "customer@gmail.com",
                    Body = $" now uploading new prduct {request.ProductDTO.Name}",
                    subject = "send email successfully"
                };  
               await _emailSender.SendEmail(email);


            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}
