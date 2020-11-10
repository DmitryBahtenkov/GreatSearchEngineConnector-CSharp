using System.Collections.Generic;
using System.Threading.Tasks;
using GSEConnectorSharp.Exceptions;
using GSEConnectorSharp.Models;
using GSEConnectorSharp.Operations;

namespace GSEConnectorSharp
{
    public class SearchOperations : OperationsBase
    {
        private string Url { get; set; }

        public SearchOperations(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Полнотекстовый поиск по индексу
        /// </summary>
        /// <param name="indexModel"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        /// <exception cref="GSEException"></exception>
        public async Task<List<DocumentModel>> FulltextSearch(IndexModel indexModel, SearchModel searchModel)
        {
            var uri = Url + "fulltext/" + indexModel;
            var response = await ApiRequest.SendGetWithJsonAndParseArray<SearchModel, DocumentModel>(uri, searchModel);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
            return response.Content;
        }
        /// <summary>
        /// Поиск по точному совпадению
        /// </summary>
        /// <param name="indexModel"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        /// <exception cref="GSEException"></exception>
        public async Task<List<DocumentModel>> MatchSearch(IndexModel indexModel, SearchModel searchModel)
        {
            var uri = Url + "match/" + indexModel;
            var response = await ApiRequest.SendGetWithJsonAndParseArray<SearchModel, DocumentModel>(uri, searchModel);
            if(!response.IsSuccess)
                throw new GSEException(response.ErrorMessage);
            return response.Content;
        }
    }
}