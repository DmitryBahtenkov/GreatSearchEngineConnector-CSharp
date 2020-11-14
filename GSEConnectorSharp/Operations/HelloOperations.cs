using System.Threading.Tasks;

namespace GSEConnectorSharp.Operations
{
    /// <summary>
    /// :)
    /// </summary>
    public class HelloOperations : OperationsBase
    {
        private string Url { get; set; }
        
        public HelloOperations(string url)
        {
            Url = url;
        }
        
        public async Task<bool> TestConnection()
        {
            var response = await ApiRequest.SendGetAndParseString(Url);
            return response.IsSuccess;
        }
    }
}