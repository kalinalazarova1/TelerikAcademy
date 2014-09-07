namespace Bookstore.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Bookstore.Data;
    using Bookstore.Models;

    public class DataParser
    {
        private BookstoreContext db;
        private XElement bookstore;

        public DataParser(BookstoreContext db, XElement bookstore)
        {
            this.db = db;
            this.bookstore = bookstore;
        }

        public void Parse()
        {
            var books = this.bookstore.Descendants("book");
            foreach (var book in books)
            {
                var current = new Book()
                {
                    Title = book.Element("title").Value,
                    WebSite = book.Element("web-site") != null ? book.Element("web-site").Value : null,
                };

                ParseIsbn(this.db, book, current);
                ParsePrice(book, current);
                ParseAuthors(this.db, book, current);
                ParseReviews(this.db, book, current);

                this.db.Books.Add(current);
                this.db.SaveChanges();
            }
        }

        private static void ParsePrice(XElement book, Book current)
        {
            if (book.Element("price") != null)
            {
                current.Price = decimal.Parse(book.Element("price").Value);
            }
        }

        private static void ParseIsbn(BookstoreContext db, XElement book, Book current)
        {
            if (book.Element("isbn") != null)
            {
                var currentIsbn = book.Element("isbn").Value;
                if (db.Books.Any(b => b.Isbn == currentIsbn))
                {
                    throw new ApplicationException("Duplicated ISBN number!");
                }

                current.Isbn = currentIsbn;
            }
        }

        private static void ParseReviews(BookstoreContext db, XElement book, Book current)
        {
            var reviews = book.Descendants("review");
            if (reviews.Count() > 0)
            {
                foreach (var review in reviews)
                {
                    var currentReview = new Review()
                    {
                        Content = review.Value,
                        Date = review.Attribute("date") != null ? DateTime.Parse(review.Attribute("date").Value) : DateTime.Now,
                    };

                    if (review.Attribute("author") != null)
                    {
                        var authorName = review.Attribute("author").Value;
                        if (db.Authors.Any(a => a.Name == authorName))
                        {
                            currentReview.Author = db.Authors.First(a => a.Name == authorName);
                        }
                        else
                        {
                            var createdAuthor = new Author() { Name = authorName };
                            db.Authors.Add(createdAuthor);
                            currentReview.Author = createdAuthor;
                        }
                    }

                    current.Reviews.Add(currentReview);
                }
            }
        }

        private static void ParseAuthors(BookstoreContext db, XElement book, Book current)
        {
            var authors = book.Element("authors");
            if (authors != null)
            {
                foreach (var author in authors.Elements())
                {
                    var authorName = author.Value;
                    if (db.Authors.Any(a => a.Name == authorName))
                    {
                        current.Authors.Add(db.Authors.First(a => a.Name == authorName));
                    }
                    else
                    {
                        var createdAuthor = new Author() { Name = authorName };
                        db.Authors.Add(createdAuthor);
                        current.Authors.Add(createdAuthor);
                    }
                }
            }
        }
    }
}
