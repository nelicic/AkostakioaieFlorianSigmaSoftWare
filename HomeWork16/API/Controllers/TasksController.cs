using System.Linq;
using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TasksController : BaseApiController
{
    private readonly DataContext _context;
    public TasksController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("task1")]
    public async Task<ActionResult<List<Showtime>>> ShowtimesOfCurrentWeek()
    {
        DateTime currentDate = DateTime.UtcNow;
        int days = 7 - (int)currentDate.DayOfWeek;
        DateTime endOfTheWeek = currentDate.AddDays(days);
        DateTime beginOfTheWeek = endOfTheWeek.AddDays(-6);

        return await _context.Showtimes
            .Where(x => x.Date > beginOfTheWeek && x.Date < endOfTheWeek)
                .Include(x => x.Movie)
                    .ToListAsync();
    }

    [HttpGet("task2")]
    public async Task<ActionResult<List<Hall>>> AvailableSeatsForShow(int showId)
    {
        var show = await _context.Showtimes.FirstOrDefaultAsync(x => x.Id == showId);
        List<Hall> availableHall = await _context.Halls.Where(x => show.CinemaHallId == x.HallId).ToListAsync();
        List<int> bookedSeats = await _context.Bookings.Where(x => x.ShowTimeId == showId).Select(x => x.SeatNumber).ToListAsync();

        foreach (int index in bookedSeats)
            availableHall = availableHall.Where(x => x.SeatId != index).ToList();

        return availableHall;
    }

    [HttpGet("task3")]
    public async Task<ActionResult<List<Hall>>> SeatsWhichWereNeverBooked()
    {
        List<Hall> halls = await _context.Halls.ToListAsync();
        List<Booking> booking = await _context.Bookings.Include(x => x.Showtime).ToListAsync();
        int max = halls.Max(x => x.HallId);

        List<List<int>> hallsWithBookedSeats = new();
        List<int> bookedSeats = new();

        for (int i = 1; i <= max; i++)
        {
            bookedSeats = booking.Where(x => x.Showtime.CinemaHallId == i).Select(x => x.SeatNumber).ToList();
            hallsWithBookedSeats.Add(bookedSeats);
        }    

        for (int i = 1; i <= max; i++)
        {
            List<int> current = hallsWithBookedSeats[i - 1];
            List<Hall> hall = halls.Where(x => x.HallId == i).ToList();

            hall.ForEach(x => {
                foreach (var i in current)
                {
                    if (x.SeatId == i)
                        halls.Remove(x);
                }
            });
        }    

        return halls;
    }

    [HttpGet("task4")]
    public async Task<ActionResult<List<NameSum>>> CalculateAllMoney()
    {
        var bookings = await _context.Bookings.Include(x => x.Showtime).ThenInclude(x => x.Movie).ToListAsync();
        var result = bookings.GroupBy(x => x.Showtime.Movie.MovieName);

        decimal sum;

        List<NameSum> res = new();
        foreach (var item in result)
        {
            sum = 0;
            foreach (var booking in item)
                sum += booking.Showtime.Movie.Price;
            res.Add(new NameSum(item.Key, sum));
        }

        return res.OrderByDescending(x => x.Total).ToList();
    }

    [HttpGet("task5")]
    public async Task<ActionResult<List<NameSum>>> MostMoneySpent(string begin, string end)
    {
        DateTime dbegin = DateTime.Parse(begin);
        DateTime dend = DateTime.Parse(end);

        var booking = await _context.Bookings
            .Include(x => x.Showtime)
                .ThenInclude(x => x.Movie)
                    .Include(x => x.User).ToListAsync();

        var result = booking
            .Where(x => x.Showtime.Date > dbegin && x.Showtime.Date < dend)
                .GroupBy(x => x.User.Name);
        
        decimal sum;
        List<NameSum> res = new();
        foreach (var item in result)
        {
            sum = 0;
            foreach (var booking1 in item)
                sum += booking1.Showtime.Movie.Price;
            res.Add(new NameSum(item.Key, sum));
        }

        int max = res.Count < 3 ? res.Count : 3;
        
        return res.GetRange(0, max).OrderByDescending(x => x.Total).ToList();
    }

    [HttpGet("task6")]
    public async Task<ActionResult<List<int>>> HallsWithLessVisitors()
    {
        DateTime currentDate = DateTime.UtcNow;
        int days = 7 - (int)currentDate.DayOfWeek;

        DateTime endOfTheWeek = currentDate.AddDays(days);
        DateTime beginOfTheWeek = endOfTheWeek.AddDays(-6);

        DateTime endOfTheLastWeek = endOfTheWeek.AddDays(-7);
        DateTime beginOfTheLastWeek = beginOfTheWeek.AddDays(-7);

        var booking = await _context.Bookings.Include(x => x.Showtime).ToListAsync();

        int max = booking.Max(x => x.Showtime.CinemaHallId);
        List<int> amountForThisWeek = new();
        for (int i = 1; i <= max; i++)
        {
            var amount = booking.Where(x => x.Showtime.CinemaHallId == i && 
                                    x.Showtime.Date > beginOfTheWeek && x.Showtime.Date < endOfTheWeek)
                                        .Count();
            
            amountForThisWeek.Add(amount);
        }

        List<int> amountForLastWeek = new();
        for (int i = 1; i <= max; i++)
        {
            var amount = booking.Where(x => x.Showtime.CinemaHallId == i && 
                                    x.Showtime.Date > beginOfTheLastWeek && x.Showtime.Date < endOfTheLastWeek)
                                        .Count();
            
            amountForLastWeek.Add(amount);
        }

        List<int> hallIds = new();
        for (int i = 0; i < max - 1; i++)
        {
            if (amountForLastWeek[i] > amountForThisWeek[i])
                hallIds.Add(i + 1);
        }

        return hallIds;
    }

    public record NameSum(string Name, decimal Total);
}
