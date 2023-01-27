using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class HallsController : BaseApiController
{
    private readonly DataContext _context;
    public HallsController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("Halls")]
    public async Task<ActionResult<List<Hall>>> GetHalls()
    {
        return await _context.Halls.ToListAsync();
    }
}
