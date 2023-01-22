using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost("create-user")]
    public async Task<ActionResult> CreateUser(User user)
    {
        var userExists = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
        if (userExists != null)
            return BadRequest("User with such identifier exists");

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpPost("update-user")]
    public async Task<ActionResult> UpdateMovie(int id, User updatedUser)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return NotFound("User with such identifier doesn't exist");

        user.Name = updatedUser.Name;
        
        _context.Update(user);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpDelete("delete-user")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return NotFound("User with such identifier doesn't exist");

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
        return Ok("Success");
    }
}