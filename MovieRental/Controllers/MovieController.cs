using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieRentalDBContext DBcontext;

        public MovieController(MovieRentalDBContext context)
        {
            DBcontext = context;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return DBcontext.Movie.ToList();
        }

        [HttpGet("id={id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = DBcontext.Movie.FirstOrDefault(m => m.MovieID == id);

            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            string response = string.Empty;
            DBcontext.Movie.Add(movie);
            DBcontext.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new {id = movie.MovieID}, movie);
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> UpdateMovie(int id,[FromBody] Movie movie)
        {
            if(id != movie.MovieID)
                return BadRequest();

            DBcontext.Entry(movie).State = EntityState.Modified;

            try
            {
                await DBcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBcontext.Movie.Any(m => m.MovieID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = DBcontext.Movie.Find(id);
            if (movie == null)
                return NotFound();

            DBcontext.Movie.Remove(movie);
            await DBcontext.SaveChangesAsync();

            return NoContent();

        }
    }
}
