﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Requests.Command
{
    public class DeleteProductCommand : IRequest
    {
        public int id { get; set; }
    }
}
