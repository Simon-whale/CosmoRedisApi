using Microsoft.EntityFrameworkCore;
using RedisCosmoApi.Models;

namespace RedisCosmoApi.Context;

public class CosmoContext : DbContext
{
    public CosmoContext() { }
    public CosmoContext(DbContextOptions<CosmoContext> options) : base(options) { }
    
    public DbSet<UserDetails> UserDetails { get; set; }
}