using Newtonsoft.Json;

namespace RedisCosmoApi.Models;

public class UserDetails
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public Address? Address { get; set; }
}