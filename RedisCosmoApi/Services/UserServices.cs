using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using RedisCosmoApi.Context;
using RedisCosmoApi.Interfaces;
using RedisCosmoApi.Models;

namespace RedisCosmoApi.Services;

//TODO: Add subquery
public class UserServices : IUserDetails
{
    private readonly CosmoContext _cosmoContext;
    private readonly IRedisClient _redisClient;
    
    public UserServices(CosmoContext cosmoContext, IRedisClient redisClient)
    {
        _cosmoContext = cosmoContext;
        _redisClient = redisClient;
    }

    public async Task<UserDetails> GetUser(int id)
    {
        var existingItem = await _redisClient.GetValue(id.ToString());
        if (!String.IsNullOrEmpty(existingItem))
        {
            return JsonSerializer.Deserialize<UserDetails>(existingItem);
        }
        
        var found = await _cosmoContext.UserDetails.FindAsync(id);
        await _redisClient.SetValue(found.Lastname, found, 120);
        return found;
    }

    public async Task<bool> CreateUser(UserDetails details)
    {
        var exisiting = await _cosmoContext.UserDetails.FindAsync(details.Id);
        if (exisiting is null)
        {
            await _cosmoContext.UserDetails.AddAsync(details);
            await _cosmoContext.SaveChangesAsync();

            await _redisClient.SetValue(details.Lastname, details, 120);
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteUser(int Id)
    {
        var existing = await _cosmoContext.UserDetails.FindAsync(Id);
        if (existing is not null)
        {
            _cosmoContext.UserDetails.Remove(existing);
            await _cosmoContext.SaveChangesAsync();
            await _redisClient.DeleteValue(existing.Lastname);
            return true;
        }

        return false;
    }
}