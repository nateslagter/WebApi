namespace WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Module>? Modules { get; } = new();
    }
}
