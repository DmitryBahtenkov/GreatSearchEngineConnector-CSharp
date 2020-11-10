using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GSEConnectorSharp.Models;
using Newtonsoft.Json;

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

        public async Task<ResponseModel<string>> SendGetAndParseString(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            return response.IsSuccessStatusCode 
                ? new ResponseModel<string>(content: await response.Content.ReadAsStringAsync()) 
                : new ResponseModel<string>($"Request return not OK status: {response.StatusCode}");
        }

        public async Task<ResponseModel<T>> SendPostJsonWithoutResponse<T>(string uri, T obj)
        { 
            var response = await _httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json"));
            return response.IsSuccessStatusCode 
                ? new ResponseModel<T>(obj) 
                : new ResponseModel<T>($"Index not created, status code: {response.StatusCode}");
        }

        public async Task<ResponseModel<T>> SendGetAndParseObject<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<T>($"Request return not OK status code: {response.StatusCode}");
            }
            var obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return new ResponseModel<T>(obj);
        }
        
        public async Task<ResponseModel<List<T>>> SendGetAndParserArray<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<List<T>>($"Request return not OK status code: {response.StatusCode}");
            }
            var array = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());
            //десериализуем каждый элемент по отдельности, так как оно не хочет конвертироваться в массив :(
            var result = array.Select(JsonConvert.DeserializeObject<T>).ToList();
            return new ResponseModel<List<T>>(result);
        }
    }
}
