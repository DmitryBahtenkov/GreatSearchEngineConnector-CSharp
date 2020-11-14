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

        public async Task<List<DocumentModel>> GetAllFromIndex(IndexModel indexModel)
        {
            var uri = Url + indexModel + "/all";
            var response = await ApiRequest.SendGetAndParseArray<DocumentModel>(uri);
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

        public async Task<List<string>> GetIndexes(string dbName)
        {
            var uri = Url + dbName;
            var response = await ApiRequest.SendGetAndParseObject<List<string>>(uri);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
            return response.Content;
        }

        public async Task RenameIndex(IndexModel indexModel, string newName)
        {
            var uri = Url + indexModel + "/rename?name=" + newName;
            var response = await ApiRequest.SendPut(uri);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
        }
    }
}