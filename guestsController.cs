using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    [Route("api/guest")]
    [ApiController]
    public class guestsController : ControllerBase
    {
        private readonly guestDbContext _context;

        public guestsController(guestDbContext context)
        {
            _context = context;
        }

        // GET: api/guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<guest>>> Getguest()
        {
            return await _context.guest.ToListAsync();
        }

        // GET: api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<guest>> Getguest(int id)
        {
            var guest = await _context.guest.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        // PUT: api/guests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putguest(int id, guest guest)
        {
            if (id != guest.guest_Id)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!guestExists(id))
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

        // POST: api/guests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<guest>> Postguest(guest guest)
        {
            _context.guest.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getguest", new { id = guest.guest_Id }, guest);
        }

        // DELETE: api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteguest(int id)
        {
            var guest = await _context.guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.guest.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool guestExists(int id)
        {
            return _context.guest.Any(e => e.guest_Id == id);
        }
    }
}
