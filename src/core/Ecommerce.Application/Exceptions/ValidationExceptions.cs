using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {

        public ValidationExceptions(ValidationResult validatorResult)
        {
            foreach (var err in validatorResult.Errors)
            {
                Errors.Add(err.ErrorMessage);

            }
        }

        public List<string> Errors { get; set; }
    }
}
