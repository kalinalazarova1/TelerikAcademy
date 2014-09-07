namespace TelerikAcademyForumRss
{
    using System;

    public class Item
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Link { get; set; }

        public override string ToString()
        {
            return "Title: " +
                this.Title +
                Environment.NewLine +
                "Category: " +
                this.Category;
        }
    }
}
