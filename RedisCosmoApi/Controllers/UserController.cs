using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using RedisCosmoApi.Context;
using RedisCosmoApi.Interfaces;
using RedisCosmoApi.Models;

namespace RedisCosmoApi.Controllers;

[ApiController]
[Route("controller/[Action]")]
public class UserController : Controller
{
    private readonly CosmoContext _cosmoContext;
    private readonly IUserDetails _userDetails;
    
    public UserController(CosmoContext cosmoContext, IUserDetails userDetails)
    {
        _cosmoContext = cosmoContext;
        _userDetails = userDetails;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserDetails(int id)
    {
        return Ok(await _userDetails.GetUser(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDetails details)
    {
        return Ok(await _userDetails.CreateUser(details));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok(await _userDetails.DeleteUser(id));
    }
}