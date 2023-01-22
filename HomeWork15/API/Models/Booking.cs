using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Booking
{
    public int Id { get; set; }

    [ForeignKey("Showtime")]
    public int ShowTimeId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; } 
    public int SeatNumber { get; set; }


    // Relations
    public User User { get; set; }
    public Showtime Showtime { get; set; }
}
