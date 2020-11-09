using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using GSEConnectorSharp.Exceptions;

namespace GSEConnectorSharp
{
    public class ApiClient
    {
        public string Url { get; set; }
        private readonly string _host;
        private readonly int _port;

        private readonly ApiRequest _apiRequest;

        /// <summary>
        /// Use custom connection
        /// </summary>
        /// <param name="connectionString"></param>
        public ApiClient(string connectionString)
        {
            Url = connectionString;
            _apiRequest = new ApiRequest();
        }

        /// <summary>
        /// use default data or custom connect
        /// </summary>
        /// <param name="host"> host address without "https://"</param>
        /// <param name="port"></param>
        /// <param name="useSsl">use ssl for create "http" or "https" protocol</param>
        public ApiClient(string host = "localhost", int port = 5000, bool useSsl = false)
        {
            _host = host;
            _port = port;
            Url = useSsl ? $"https://{host}:{port}/" : $"http://{host}:{port}/";
            _apiRequest = new ApiRequest();
        }

        public async Task<bool> TestConnection()
        {
            var response = await _apiRequest.SendGetAndParseString(Url);
            return response.IsSuccess;
        }
    }
}