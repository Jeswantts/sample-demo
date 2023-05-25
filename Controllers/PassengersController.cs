using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flyhigh_Airlines.Models;

namespace Flyhigh_Airlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly FlyhighContext _context;

        public PassengersController(FlyhighContext context)
        {
            _context = context;
        }

        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passengers>>> GetPassengers()
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            return await _context.Passengers.ToListAsync();
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passengers>> GetPassengers(int id)
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            var passengers = await _context.Passengers.FindAsync(id);

            if (passengers == null)
            {
                return NotFound();
            }

            return passengers;
        }

        // PUT: api/Passengers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengers(int id, Passengers passengers)
        {
            if (id != passengers.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(passengers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Passengers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passengers>> PostPassengers(Passengers passengers)
        {
          if (_context.Passengers == null)
          {
              return Problem("Entity set 'FlyhighContext.Passengers'  is null.");
          }
            _context.Passengers.Add(passengers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengers", new { id = passengers.BookingId }, passengers);
        }

        // DELETE: api/Passengers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengers(int id)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var passengers = await _context.Passengers.FindAsync(id);
            if (passengers == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passengers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengersExists(int id)
        {
            return (_context.Passengers?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
