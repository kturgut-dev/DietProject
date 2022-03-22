namespace Web.Models
{
    public class ViewMessage
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public ViewMessage(string _message,string _type)
        {
            Message = _message;
            Type = _type;
        }
    }
}
