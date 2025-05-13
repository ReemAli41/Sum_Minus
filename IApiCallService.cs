using Sum_Minus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Minus.Services
{
    public interface IApiCallService
    {
        Task<OperationResponse> CallApiAsync();
    }
}
