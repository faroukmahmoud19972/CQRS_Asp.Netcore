using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models.Email
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string subject { get; set; }
        public string Body { get; set; }
    }
}
