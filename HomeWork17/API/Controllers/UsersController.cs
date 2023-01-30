using API.Helpers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    private readonly IEmailValidator _emailValidator;

    public UsersController(DataContext context, IEmailValidator emailValidator)
    {
        _context = context;
        _emailValidator = emailValidator;
    }

    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost("create-user")]
    public async Task<ActionResult> CreateUser(User user)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input");
        
        if (!_emailValidator.IsValid(user.Email))
            return BadRequest("Invalid email");

        var userExists = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
        if (userExists != null)
            return BadRequest("User with such identifier exists");

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpPost("update-user")]
    public async Task<ActionResult> UpdateUser(int id, User updatedUser)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return NotFound("User with such identifier doesn't exist");

        if (!_emailValidator.IsValid(updatedUser.Email))
            return BadRequest("Invalid email");

        user.Name = updatedUser.Name;
        
        _context.Update(user);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpDelete("delete-user")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return NotFound("User with such identifier doesn't exist");

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
        return Ok("Success");
    }
}