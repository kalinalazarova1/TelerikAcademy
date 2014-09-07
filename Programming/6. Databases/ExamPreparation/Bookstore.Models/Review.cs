namespace Bookstore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Review
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? AuthorId { get; set; }

        public string Content { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Author Author { get; set; }
    }
}
