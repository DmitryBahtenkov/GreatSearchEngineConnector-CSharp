using System.Threading.Tasks;
using GSEConnectorSharp;
using GSEConnectorSharp.Models;
using NUnit.Framework;

namespace GSEConnectorSharpTests.OperationsTests
{
    public class SearchOperationTests
    {
        private ApiClient _apiClient;
        private IndexModel _indexModel;
        private SearchModel _searchModel;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("http://localhost:5000/");
            _indexModel = new IndexModel("wsws", "swsw");
            _searchModel = new SearchModel
            {
                Key = "Text",
                Text = "Reqbin api"
            };
        }

        [Test]
        public async Task FulltextSearchTest()
        {
            var result = await _apiClient.SearchOperations.FulltextSearch(_indexModel, _searchModel);
            Assert.NotNull(result);
        }
        
        [Test]
        public async Task MatchSearchTest()
        {
            var result = await _apiClient.SearchOperations.MatchSearch(_indexModel, _searchModel);
            Assert.NotNull(result);
        }
    }
}