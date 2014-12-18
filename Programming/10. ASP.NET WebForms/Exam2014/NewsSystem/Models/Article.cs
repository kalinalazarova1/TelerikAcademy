﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Models
{
    
    public class Article
    {
        private ICollection<Like> likes;

        public Article()
        {
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        public virtual AppUser Author { get; set; }

        public string AuthorId { get; set; }

        public virtual ICollection<Like> Likes 
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            } 
        }
    }
}