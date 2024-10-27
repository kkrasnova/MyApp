namespace MyApp.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; } // Поле для ввода электронной почты
        public string Password { get; set; } // Поле для ввода пароля
        public bool RememberMe { get; set; } // Поле для запоминания пользователя
    }
}