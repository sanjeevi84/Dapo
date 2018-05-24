using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapo.ViewModel
{
    public class BaseResponse
    {
        public OperationResult OperationResult { get; set; }
        public BaseResponse()
        {
            OperationResult = new OperationResult();
        }
    }
}
