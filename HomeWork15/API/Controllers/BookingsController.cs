using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BookingsController : BaseApiController
{
    private readonly DataContext _context;
    public BookingsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("Bookings")]
    public async Task<ActionResult<List<Booking>>> GetBookings()
    {
        return await _context.Bookings
            .Include(x => x.Showtime)
            .ThenInclude(x => x.Movie)
            .Include(x => x.User)
            .ToListAsync();
    }

    [HttpPost("buy-ticket")]
    public async Task<ActionResult> BookASeat(int showtimeId, int seatId, int userId)
    {
        bool isAvailable = await Check(showtimeId, seatId, userId);
        if (!isAvailable)
            return BadRequest("Wrong input");

        // Showtime show = await _context.Showtimes.Where(x => x.Id == showtimeId).FirstOrDefaultAsync();
        // if (show.Date < DateTime.UtcNow)
        //     return NotFound("This session was performed!");

        Booking booked = await _context.Bookings
            .Where(x => x.SeatNumber == seatId && x.ShowTimeId == showtimeId).FirstOrDefaultAsync();

        if (booked != null)
            return BadRequest("This seat is already booked!");

        Booking booking = new Booking()
            { 
                ShowTimeId = showtimeId, 
                SeatNumber = seatId, 
                UserId = userId 
            };

        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        
        return Ok("Success");
    }

    private async Task<bool> Check(int showtimeId, int seatId, int userId)
    {
        Showtime show = await _context.Showtimes.Where(x => x.Id == showtimeId).FirstOrDefaultAsync();
        Hall hall = await _context.Halls.Where(x => x.HallId == show.CinemaHallId && x.Available).FirstOrDefaultAsync();
        User user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

        if (show != null && hall != null && user != null)
            return true;

        return false;
    }
}
