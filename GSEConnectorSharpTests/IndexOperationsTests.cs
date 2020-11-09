using System.Threading.Tasks;
using GSEConnectorSharp.Models;
using GSEConnectorSharp.Operations;
using NUnit.Framework;

namespace GSEConnectorSharpTests
{
    public class IndexOperationsTests
    {
        private IndexOperations _indexOperations;

        [SetUp]
        public void Setup()
        {
            _indexOperations = new IndexOperations("http://localhost:5000/");
        }

        [Test]
        public async Task GetAllTest()
        {
            var result = await _indexOperations.GetAllFromIndex(new IndexModel("wsws", "swsw"));
            Assert.NotNull(result);
        }
        
        [Test]
        public async Task GetByIdTest()
        {
            var result = await _indexOperations.GetByIdFromIndex(new IndexModel("wsws", "swsw"), 0);
            Assert.NotNull(result);
        }
    }
}