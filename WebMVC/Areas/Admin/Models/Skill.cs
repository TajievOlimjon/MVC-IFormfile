namespace WebMVC.Areas.Admin.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Percent { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
