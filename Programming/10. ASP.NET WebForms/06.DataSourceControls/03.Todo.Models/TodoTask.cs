using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Todo.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime LastModified { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
