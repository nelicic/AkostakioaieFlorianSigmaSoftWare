using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ShowtimeController : BaseApiController
{
    private readonly DataContext _context;
    public ShowtimeController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("Showtimes")]
    public async Task<ActionResult<List<Showtime>>> GetShowtimes()
    {
        return await _context.Showtimes.Include(x => x.Movie).ToListAsync();
    }

    [HttpPost("add-showtime")]
    public async Task<ActionResult> AddShowtime(Showtime showtime, int movieId)
    {
        var showtimeExists = await _context.Showtimes.SingleOrDefaultAsync(x => x.Id == showtime.Id);
        if (showtimeExists != null)
            return BadRequest("Showtime already exists!");

        Movie movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == movieId);
        if (movie == null)
            return NotFound("Movie with such id doesn't exist");

        showtime.Movie = movie;
        showtime.MovieId = movie.Id;

        _context.Showtimes.Add(showtime);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpGet("future-sessions")]
    public async Task<ActionResult<List<Showtime>>> GetFutureSessions()
    {
        return await _context.Showtimes.Include(x => x.Movie).Where(x => x.Date >= DateTime.UtcNow).ToListAsync();
    }

    [HttpGet("available-seats")]
    public async Task<ActionResult<List<Hall>>> GetAvailableSeats(int showTimeId)
    {
        Showtime showtime = await _context.Showtimes.SingleOrDefaultAsync(x => x.Id == showTimeId);

        return await _context.Halls.Where(x => x.Available == true && x.HallId == showtime.CinemaHallId).ToListAsync();
    }
}
