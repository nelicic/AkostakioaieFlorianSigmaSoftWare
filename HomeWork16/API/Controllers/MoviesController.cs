using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers;

public class MoviesController : BaseApiController
{
    protected readonly DataContext _context;
    public MoviesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("movies")]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    [HttpPost("create-movie")]
    public async Task<ActionResult> CreateMovie(Movie movie)
    {
        var movieExists = await _context.Movies.SingleOrDefaultAsync(x => x.Id == movie.Id);
        if (movieExists != null)
            return BadRequest("User with such identifier exists");

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpPost("update-movie")]
    public async Task<ActionResult> UpdateMovie(int id, Movie updatedMovie)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
        if (movie == null)
            return BadRequest("Movie with such identifier doesn't exist");

        movie.MovieName = updatedMovie.MovieName;
        movie.Price = updatedMovie.Price;

        _context.Update(movie);

        await _context.SaveChangesAsync();
        return Ok("Success");
    }

    [HttpDelete("delete-movie")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
        if (movie == null)
            return BadRequest("Movie with such identifier doesn't exist");

        _context.Movies.Remove(movie);

        await _context.SaveChangesAsync();
        return Ok("Success");
    }
}
