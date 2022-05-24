namespace Web.Models
{
    public class ChatViewDTO
    {
        public UserTypes UserType { get; set; }
    }

    public enum UserTypes
    {
        Dietitian,
        Customer,
        NoActivated//daha tamamlanmayan süreç
    }
}
