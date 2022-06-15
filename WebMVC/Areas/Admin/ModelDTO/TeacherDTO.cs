namespace WebMVC.Areas.Admin.ModelDTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class TeacherSkill
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public DateTime Birthday { get; set; }
        public int SkillId { get; set; }
        public string? Title { get; set; }
        public int Percent { get; set; }
    }
}
