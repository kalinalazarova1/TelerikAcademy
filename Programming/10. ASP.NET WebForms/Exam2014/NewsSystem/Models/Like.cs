using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public virtual Article Article { get; set; }

        public int ArticleId { get; set; }

        public virtual AppUser Reader { get; set; }

        public string ReaderId { get; set; }
    }
}