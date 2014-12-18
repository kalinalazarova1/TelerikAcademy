using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.SimpleChat.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}