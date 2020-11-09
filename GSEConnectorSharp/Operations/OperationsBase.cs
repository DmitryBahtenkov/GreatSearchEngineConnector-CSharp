namespace GSEConnectorSharp.Operations
{
    public class OperationsBase
    {
        protected ApiRequest ApiRequest { get; set; }

        public OperationsBase()
        {
            ApiRequest = new ApiRequest();
        }
    }
}