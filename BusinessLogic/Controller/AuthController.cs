using BusinessLogic.Repository;

namespace BusinessLogic.Controller
{
    public class AuthController
    {
        private readonly UserRepository userRepository = new UserRepository();

        public LoginResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new LoginResult { Success = false, Message = "Username and password are required." };

            var user = userRepository.GetByUsername(username);

            if (user == null || user.PasswordHash != HashPassword(password))
                return new LoginResult { Success = false, Message = "Invalid username or password." };

            return new LoginResult { Success = true, Role = user.Role, Username = user.Username };
        }

        private string HashPassword(string password)
        {
            return password;
        }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
    }
}