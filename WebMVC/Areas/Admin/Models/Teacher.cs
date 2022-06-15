namespace WebMVC.Areas.Admin.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public DateTime Birthday { get; set; }
        public virtual List<Skill>? Skills { get; set; }
    }
}
