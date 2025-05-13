using Sum_Minus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Minus.Services
{
    public class OperationService : IOperationService
    {
         public OperationResponse Sum(OperationRequest request)
        {
            double result = request.Number1 + request.Number2;
            return new OperationResponse
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public OperationResponse Minus(OperationRequest request)
        {
            double result = request.Number1 - request.Number2;
            return new OperationResponse
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }
    }
}
