using System.Threading.Tasks;
using GSEConnectorSharp;
using GSEConnectorSharpTests.Models;
using NUnit.Framework;

namespace GSEConnectorSharpTests
{
    public class ApiClientTests
    {
        private ApiClient _apiClient;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task UseDefaultConnectionTest()
        {
            _apiClient = new ApiClient();
            Assert.True(await _apiClient.HelloOperations.TestConnection());
        }
        
        [Test]
        public async Task UseCustomConnectionTest()
        {
            _apiClient = new ApiClient("https://localhost:5001");
            Assert.True(await _apiClient.HelloOperations.TestConnection());
        }
        
    }
}