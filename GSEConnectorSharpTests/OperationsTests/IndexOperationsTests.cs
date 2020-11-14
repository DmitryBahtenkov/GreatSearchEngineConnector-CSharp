using System;
using System.Threading.Tasks;
using GSEConnectorSharp;
using GSEConnectorSharp.Models;
using GSEConnectorSharp.Operations;
using GSEConnectorSharpTests.Models;
using NUnit.Framework;

namespace GSEConnectorSharpTests.OperationsTests
{
    public class IndexOperationsTests
    {
        private ApiClient _apiClient;
        private IndexModel _indexModel;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient("http://localhost:5000/");
            _indexModel = new IndexModel("wsws", "swsw");
        }

        [Test]
        public async Task GetAllTest()
        {
            try
            {
                var result = await _apiClient.IndexOperations.GetAllFromIndex(_indexModel);
                Assert.NotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        
        [Test]
        public async Task GetByIdTest()
        {
            try
            {
                var result = await _apiClient.IndexOperations.GetByIdFromIndex(_indexModel, 0);
                Assert.NotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Test]
        public async Task CreateObjectTest()
        {
            try
            {
                await _apiClient.IndexOperations.CreateIndexAndAddObject(_indexModel, new TestModel
                {
                    Name = "AzaZ",
                    Text = "ReqBin API Tester is a free online API"
                });
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task RenameIndexTest()
        {
            try
            {
                await _apiClient.IndexOperations.RenameIndex(_indexModel, "uuu");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [Test]
        public async Task GetIndexesTest()
        {
            try
            {
                var result = await _apiClient.IndexOperations.GetIndexes("test");
                Assert.IsNotEmpty(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}