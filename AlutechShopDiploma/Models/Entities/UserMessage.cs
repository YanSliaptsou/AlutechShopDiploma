using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Entities
{
    public class UserMessage
    {
        private int userMessageID;
        private string userId;
        private string messageTopic;
        private string messageText;

        public int UserMessageID { get => userMessageID; set => userMessageID = value; }
        public string UserId { get => userId; set => userId = value; }
        public string MessageTopic { get => messageTopic; set => messageTopic = value; }
        public string MessageText { get => messageText; set => messageText = value; }
    }
}