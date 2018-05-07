using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapo.ViewModel
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public OperationResult()
        {
            IsSuccess = true;
            ResponseMessage = "Success";
        }
    }
}
