using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя ?")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Введите email  ?")]
       // [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Введите пароль ?")]
        [StringLength(50, ErrorMessage = "Пароль должен содержать минимум 4 символов ?", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Потвердите пароль ?")]
        [StringLength(50, ErrorMessage = "Пароль должен содержать минимум 4 символов ?", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают ?")]
        public string? ConfirmPassword { get; set; }

        

    }

    
}
