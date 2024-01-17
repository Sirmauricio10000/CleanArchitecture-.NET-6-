using Core.Entities;

namespace Core.Interfaces.Authentication
{
    public interface IJwtServices
    {
        Task<string> GenerateToken(User user);
    }
}