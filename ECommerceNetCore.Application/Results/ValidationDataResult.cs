using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Results
{
    public class ValidationDataResult : DataResult<List<string>>
    {
        public ValidationDataResult(List<string> errors, string message) : base(errors, false, message)
        {
            Errors = errors;
        }

        public ValidationDataResult(List<string> errors) : base(errors, false)
        {
            Errors = errors;
        }
        public ValidationDataResult(bool success, string message) : base(success, message)
        {

        }
        public ValidationDataResult()
        {

        }

        public List<string> Errors { get; set; }
    }
}
