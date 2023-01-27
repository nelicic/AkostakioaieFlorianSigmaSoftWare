using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace API.Models;

public class Showtime
{
    public int Id { get; set; }
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public int CinemaHallId { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }

    // Relations 
    public Movie Movie { get; set; }
}
