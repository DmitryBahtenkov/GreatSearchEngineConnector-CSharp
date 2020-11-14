using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GSEConnectorSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
            var response = await _httpClient.PostAsync(uri,
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json"));
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

            var str = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<T>(str);
            return new ResponseModel<T>(obj);
        }
        
        public async Task<ResponseModel<List<T>>> SendGetAndParseArray<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<List<T>>($"Request return not OK status code: {response.StatusCode}");
            }

            var str = await response.Content.ReadAsStringAsync();
            var array = JsonConvert.DeserializeObject<string[]>(str);
            var result = new List<T>();
            foreach (var item in array)
            {
                result.Add(JsonConvert.DeserializeObject<T>(item));
            }
            return new ResponseModel<List<T>>(result);
        }

        public async Task<ResponseModel<TResult>> SendGetWithJsonAndParseObject<TItem, TResult>(string uri, TItem item)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.Default, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return new ResponseModel<TResult>($"Request return not OK status code: {response.StatusCode}");
            }
            
            var result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
            return new ResponseModel<TResult>(result);
        }
        
        public async Task<ResponseModel<string>> SendPut(string uri)
        {
            var response = await _httpClient.PutAsync(uri, null);
            return !response.IsSuccessStatusCode 
                ? new ResponseModel<string>(errorMessage: $"Request return not OK status code: {response.StatusCode}") 
                : new ResponseModel<string>(content:"Ok");
        }
    }
}
