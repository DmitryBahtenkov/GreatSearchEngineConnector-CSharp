using System.Collections.Generic;
using System.Threading.Tasks;
using GSEConnectorSharp.Exceptions;
using GSEConnectorSharp.Models;

namespace GSEConnectorSharp.Operations
{
    public class IndexOperations : OperationsBase
    {
        private string Url { get; set; }

        public IndexOperations(string url)
        {
            Url = url + "index/";
        }

        public async Task CreateIndexAndAddObject<T>(IndexModel indexModel, T obj)
        {
            var uri = Url + indexModel + "/add";
            var response = await ApiRequest.SendPostJsonWithoutResponse(uri, obj);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
        }

        public async Task<IEnumerable<DocumentModel>> GetAllFromIndex(IndexModel indexModel)
        {
            var uri = Url + indexModel + "/all";
            var response = await ApiRequest.SendGetAndParserArray<DocumentModel>(uri);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
            return response.Content;
        }
        
        public async Task<DocumentModel> GetByIdFromIndex(IndexModel indexModel, int id)
        {
            var uri = Url + indexModel + $"/{id}";
            var response = await ApiRequest.SendGetAndParseObject<DocumentModel>(uri);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
            return response.Content;
        }
    }
}