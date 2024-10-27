using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я користувача є обов'язковим.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Електронна пошта є обов'язковою.")]
        [EmailAddress(ErrorMessage = "Неправильний формат електронної пошти.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Неправильний формат номера телефону.")]
        public string PhoneNumber { get; set; }

        public string FilePath { get; set; } // Поле для зберігання посилання на файл
    }
}