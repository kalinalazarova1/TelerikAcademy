﻿namespace Bookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Review> reviews;
        private ICollection<Author> authors;

        public Book()
        {
            this.reviews = new HashSet<Review>();
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        [MinLength(13)]
        [MaxLength(13)]
        public string Isbn { get; set; }

        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Review> Reviews 
        {
            get 
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }
    }
}
