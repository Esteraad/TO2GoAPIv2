using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TO2GoAPIv2.Models
{
    public class CreateChatMessageDTO
    {
        public string Message { get; set; }
    }

    public class ChatMessageDTO : CreateChatMessageDTO
    {
        public int Id { get; set; }
        public GetUserDTO ApiUser { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
