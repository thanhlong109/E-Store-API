using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BaseModels
{
    public class BaseResponse
    {
        public string Message { get; set; } = string.Empty;
        public Object? Data { get; set; }  = null;
        public required int ResponseCode { get; set; }
    }
}
