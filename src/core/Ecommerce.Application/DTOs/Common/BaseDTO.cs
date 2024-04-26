using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Common
{
    public abstract class BaseDTO<T>
    {
        public T id { get; set; }
    }
}
