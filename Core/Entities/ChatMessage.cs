using System;

namespace DietProject.Core.Entities
{
    public class ChatMessage
    {
        public Int64 Id { get; set; }//UserID
        public string LastMessage { get; set; }
        public string FullName { get; set; }
        public string LastMessageDate { get; set; }
        public bool IsLeft { get; set; }
    }
}
