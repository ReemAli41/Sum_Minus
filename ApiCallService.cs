using Sum_Minus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Minus.Services
{
    public class ApiCallService: IApiCallService
    {
        private readonly HttpClient _httpClient;

        public ApiCallService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OperationResponse> CallApiAsync()
        {
            string route = "sum"; // chage to minus also
            var request = new OperationRequest
            {
                Number1 = 10,
                Number2 = 5
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://localhost:7289/api/operation/{route}", request);

                var content = await response.Content.ReadFromJsonAsync<OperationResponse>();

                return content ?? new OperationResponse //default value of response return
                {
                    StatusCode = (int)response.StatusCode,
                    Message = "Empty response from API"
                };
            }
            catch (HttpRequestException ex)
            {
                return new OperationResponse
                {
                    StatusCode = 500,
                    Message = $"Request failed: {ex.Message}"
                };
            }
        }
    }
}

