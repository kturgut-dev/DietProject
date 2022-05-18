namespace Web.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null;

        public ResponseModel()
        {

        }

        public ResponseModel(bool _isSuccess, string msg, object _data = null)
        {
            IsSuccess = _isSuccess;
            Message = msg;
            Data = _data;
        }
    }
}
