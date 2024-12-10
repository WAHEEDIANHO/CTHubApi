using CThub.Domain.Models;

namespace CThub.Application.Common.Persistence.Authentication;

public interface IUserRepository
{
    Task AddUser(User user, string password);
    Task AddRider(User user, Rider rider);
    Task AddDriver(User user, Driver driver);
    Task<User?> GetUserByEmail(string email);
    Task<bool> CheckPassword(User user, string password);
}