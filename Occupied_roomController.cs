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
    [Route("api/occupied_room")]
    [ApiController]
    public class Occupied_roomController : ControllerBase
    {
        private readonly guestDbContext _context;

        public Occupied_roomController(guestDbContext context)
        {
            _context = context;
        }

        // GET: api/Occupied_room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occupied_room>>> Getoccupied_Rooms()
        {
            return await _context.occupied_Rooms.ToListAsync();
        }

        // GET: api/Occupied_room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Occupied_room>> GetOccupied_room(int id)
        {
            var occupied_room = await _context.occupied_Rooms.FindAsync(id);

            if (occupied_room == null)
            {
                return NotFound();
            }

            return occupied_room;
        }

        // PUT: api/Occupied_room/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupied_room(int id, Occupied_room occupied_room)
        {
            if (id != occupied_room.occupied_room_id)
            {
                return BadRequest();
            }

            _context.Entry(occupied_room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Occupied_roomExists(id))
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

        // POST: api/Occupied_room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Occupied_room>> PostOccupied_room(Occupied_room occupied_room)
        {
            _context.occupied_Rooms.Add(occupied_room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOccupied_room", new { id = occupied_room.occupied_room_id }, occupied_room);
        }

        // DELETE: api/Occupied_room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupied_room(int id)
        {
            var occupied_room = await _context.occupied_Rooms.FindAsync(id);
            if (occupied_room == null)
            {
                return NotFound();
            }

            _context.occupied_Rooms.Remove(occupied_room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Occupied_roomExists(int id)
        {
            return _context.occupied_Rooms.Any(e => e.occupied_room_id == id);
        }
    }
}
