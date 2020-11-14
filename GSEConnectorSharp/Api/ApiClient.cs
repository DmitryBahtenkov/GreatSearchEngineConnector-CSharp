using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using GSEConnectorSharp.Exceptions;
using GSEConnectorSharp.Operations;

namespace GSEConnectorSharp
{
    public class ApiClient
    {
        public string Url { get; set; }
        private readonly string _host;
        private readonly int _port;
        
        public HelloOperations HelloOperations { get; set; }
        public IndexOperations IndexOperations { get; set; }
        public SearchOperations SearchOperations { get; set; }

        /// <summary>
        /// Use custom connection, for example: https://example.com:5002
        /// </summary>
        /// <param name="connectionString"></param>
        public ApiClient(string connectionString)
        {
            Url = connectionString;
            
            HelloOperations = new HelloOperations(Url);
            IndexOperations = new IndexOperations(Url);
            SearchOperations = new SearchOperations(Url);
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
            
            HelloOperations = new HelloOperations(Url);
            IndexOperations = new IndexOperations(Url);
            SearchOperations = new SearchOperations(Url);
        }
    }
}