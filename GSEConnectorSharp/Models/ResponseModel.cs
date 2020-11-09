using System.Net;

namespace GSEConnectorSharp.Models
{
    public class ResponseModel<T>
    {
        public T Content { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseModel(T content)
        {
            Content = content;
            IsSuccess = true;
        }

        public ResponseModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }
    }
}