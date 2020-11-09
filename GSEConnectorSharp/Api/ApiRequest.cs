using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GSEConnectorSharp
{
    public class ApiRequest
    {
        private readonly HttpClient _httpClient;

        public ApiRequest(bool ignoreSsl = true)
        {
            if (ignoreSsl)
            {
                var clientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
                _httpClient = new HttpClient(clientHandler);
            }
            else
            {
                _httpClient = new HttpClient();   
            }
        }

        public async Task<string> SendGetAndParseString(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            if(response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Method return not OK status code: {response.StatusCode}");
        }
        }
    }
