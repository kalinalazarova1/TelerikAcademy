namespace Bookstore.Parsers
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Bookstore.Data;
    using Bookstore.Models;

    public class QueryParser
    {
        private BookstoreContext db;
        private XElement xmlQuery;

        public QueryParser(BookstoreContext db, XElement query)
        {
            this.db = db;
            this.xmlQuery = query;
        }

        public void Parse()
        {
            var queries = this.xmlQuery.Elements("query");
            var root = new XElement("search-results");

            foreach (var query in queries)
            {
                IQueryable<Review> queryResult;

                if (query.Attribute("type").Value == "by-period")
                {
                    queryResult = this.ParsePeriodQuery(query);
                }
                else if (query.Attribute("type").Value == "by-author")
                {
                    queryResult = this.ParseAuthorQuery(query);
                }
                else
                {
                    throw new ApplicationException("Inavlid XML query type!");
                }

                root.Add(this.ExportReviewsToXmL(queryResult));
            }

            root.Save("../../../DataFiles/reviews-search-results.xml");
        }

        private IQueryable<Review> ParsePeriodQuery(XElement query)
        {
            var start = DateTime.Parse(query.Element("start-date").Value);
            var end = DateTime.Parse(query.Element("end-date").Value);
            var queryResult = this.db.Reviews
                .Where(r => start <= r.Date && r.Date <= end);

            return queryResult;
        }

        private IQueryable<Review> ParseAuthorQuery(XElement query)
        {
            var author = query.Element("author-name").Value;
            var queryResult = this.db.Reviews
                .Where(r => r.Author.Name == author);

            return queryResult;
        }

        private XElement ExportReviewsToXmL(IQueryable<Review> reviews)
        {
            var set = new XElement("result-set");
            if (reviews.Count() > 0)
            {
                var orderedReviews = reviews.OrderBy(r => r.Date).ThenBy(r => r.Content);
                foreach (var review in orderedReviews)
                {
                    var xmlReview = new XElement("review");
                    var reviewDate = new XElement("date");
                    reviewDate.Value = review.Date.ToString("d-MMM-yyyy");
                    xmlReview.Add(reviewDate);
                    var reviewConetnt = new XElement("content");
                    reviewConetnt.Value = review.Content;
                    xmlReview.Add(reviewConetnt);
                    var reviewBook = new XElement("book");
                    var bookTitle = new XElement("title");
                    bookTitle.Value = review.Book.Title;
                    reviewBook.Add(bookTitle);
                    if (review.Book.Authors.Count > 0)
                    {
                        var bookAuthors = new XElement("authors");
                        bookAuthors.Value = string.Join(", ", review.Book.Authors.Select(a => a.Name));
                        reviewBook.Add(bookAuthors);
                    }

                    if (review.Book.Isbn != null)
                    {
                        var bookIsbn = new XElement("isbn");
                        bookIsbn.Value = review.Book.Isbn;
                        reviewBook.Add(bookIsbn);
                    }

                    if (review.Book.WebSite != null)
                    {
                        var bookUrl = new XElement("url");
                        bookUrl.Value = review.Book.WebSite;
                        reviewBook.Add(bookUrl);
                    }

                    xmlReview.Add(reviewBook);
                    set.Add(xmlReview);
                }
            }

            return set;
        }
    }
}
