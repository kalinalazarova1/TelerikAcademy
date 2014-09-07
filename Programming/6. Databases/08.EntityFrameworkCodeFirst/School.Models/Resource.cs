namespace School.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
