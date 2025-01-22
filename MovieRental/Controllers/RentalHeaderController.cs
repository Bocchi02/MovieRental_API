using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalHeaderController : ControllerBase
    {
        public readonly MovieRentalDBContext DBcontext;
        
        public RentalHeaderController(MovieRentalDBContext context)
        {
            DBcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalHeader>>> GetRentalHeaders()
        {
            var rentalHeaders = await DBcontext.RentalHeader
                .Include(rh => rh.Customer)
                .ToListAsync();

            return Ok(rentalHeaders);
        }

        [HttpGet("id={id}")]
        public ActionResult<RentalHeader> GetRentalHeaderById(int id)
        {
            var rentalHeader = DBcontext.RentalHeader
                .Include(rh => rh.Customer)
                .FirstOrDefault(rh => rh.RentalID == id);
            if(rentalHeader == null)
                return NotFound();

            return rentalHeader;
        }

        [HttpPost]
        public async Task<ActionResult<RentalHeader>> AddEnrollment([FromBody] RentalHeader rentalHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DBcontext.RentalHeader.Add(rentalHeader);
            await DBcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentalHeaderById), new { id = rentalHeader.RentalID }, rentalHeader);
        }

        [HttpPut("id={id}")]
        public async Task<IActionResult> UpdateRentalHeader(int id, [FromBody] RentalHeader rentalHeader)
        {
            if (id != rentalHeader.RentalID)
                return BadRequest();

            DBcontext.Entry(rentalHeader).State = EntityState.Modified;

            try
            {
                await DBcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBcontext.RentalHeader.Any(rh => rh.RentalID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("id={id}")]
        public async Task<IActionResult> DeleteRentalHeader(int id)
        {
            var rentalHeader = DBcontext.RentalHeader.Find(id);
            if (rentalHeader == null)
                return NotFound();

            DBcontext.RentalHeader.Remove(rentalHeader);
            await DBcontext.SaveChangesAsync();

            return NoContent();

        }

    }
}
