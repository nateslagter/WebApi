namespace WebApi.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public virtual List<Assignment>? Assignments { get; } = new();
    }
}
