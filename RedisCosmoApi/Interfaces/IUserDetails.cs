using RedisCosmoApi.Models;

namespace RedisCosmoApi.Interfaces;

public interface IUserDetails
{
    Task<UserDetails> GetUser(int id);
    Task<bool> CreateUser(UserDetails details);
    Task<bool> DeleteUser(int Id);
}