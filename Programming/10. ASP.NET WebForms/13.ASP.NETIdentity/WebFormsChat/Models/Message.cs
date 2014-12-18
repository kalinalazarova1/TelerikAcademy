using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsChat.Models
{
    public class Message
    {
        public int Id { get; set; }

        virtual public User User { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}