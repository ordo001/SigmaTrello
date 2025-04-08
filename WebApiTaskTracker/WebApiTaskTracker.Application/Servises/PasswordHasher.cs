using WebApiTaskTracker.Domain.Interfaces.Services;

namespace WebApiTaskTracker.Application.Servises;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(providedPassword,hashedPassword);
    }
}