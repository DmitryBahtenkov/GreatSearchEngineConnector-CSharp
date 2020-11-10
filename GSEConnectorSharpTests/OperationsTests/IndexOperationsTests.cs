using System;
using System.Threading.Tasks;
using GSEConnectorSharp.Models;
using GSEConnectorSharp.Operations;
using GSEConnectorSharpTests.Models;
using NUnit.Framework;

namespace GSEConnectorSharpTests.OperationsTests
{
    public class IndexOperationsTests
    {
        private IndexOperations _indexOperations;
        private IndexModel _indexModel;

        [SetUp]
        public void Setup()
        {
            _indexOperations = new IndexOperations("http://localhost:5000/");
            _indexModel = new IndexModel("wsws", "swsw");
        }

        [Test]
        public async Task GetAllTest()
        {
            var result = await _indexOperations.GetAllFromIndex(_indexModel);
            Assert.NotNull(result);
        }
        
        [Test]
        public async Task GetByIdTest()
        {
            var result = await _indexOperations.GetByIdFromIndex(_indexModel, 0);
            Assert.NotNull(result);
        }

        [Test]
        public async Task CreateObjectTest()
        {
            try
            {
                await _indexOperations.CreateIndexAndAddObject(_indexModel, new TestModel
                {
                    Name = "AzaZ",
                    Text = "ReqBin API Tester is a free online API"
                });
                //Assert.Pass();
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
            
        }
    }
}