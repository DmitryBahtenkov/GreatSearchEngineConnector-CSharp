

using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GSEConnectorSharp.Models
{
    public class DocumentModel
    {
        /// <summary>
        /// Id для доступа к документам
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тело документа
        /// </summary>
        public JToken Value { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}