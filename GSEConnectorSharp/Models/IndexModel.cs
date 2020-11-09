namespace GSEConnectorSharp.Models
{
    public class IndexModel
    {
        public string DatabaseName { get; set; }
        public string IndexName { get; set; }

        public IndexModel(string databaseName, string indexName)
        {
            DatabaseName = databaseName;
            IndexName = indexName;
        }

        public override string ToString()
        {
            return $"{DatabaseName}/{IndexName}";
        }
    }
}