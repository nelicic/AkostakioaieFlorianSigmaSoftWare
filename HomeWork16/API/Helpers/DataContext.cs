using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public virtual DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Showtime> Showtimes { get; set; }
}
