using System.Threading.Tasks;
using GSEConnectorSharp;
using NUnit.Framework;

namespace GSEConnectorSharpTests
{
    public class ApiClientTests
    {
        private ApiClient _apiClient;
        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
        }

        [Test]
        public async Task Test1()
        {
            Assert.True(await _apiClient.TestConnection());
        }
    }
}