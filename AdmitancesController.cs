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
    [Route("api/Admitances")]
    [ApiController]
    public class AdmitancesController : ControllerBase
    {
        private readonly guestDbContext _context;

        public AdmitancesController(guestDbContext context)
        {
            _context = context;
        }

        // GET: api/Admitances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admitance>>> GetAdmitance()
        {
            return await _context.Admitance.ToListAsync();
        }

        // GET: api/Admitances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admitance>> GetAdmitance(int id)
        {
            var admitance = await _context.Admitance.FindAsync(id);

            if (admitance == null)
            {
                return NotFound();
            }

            return admitance;
        }

        // PUT: api/Admitances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmitance(int id, Admitance admitance)
        {
            if (id != admitance.admit_id)
            {
                return BadRequest();
            }

            _context.Entry(admitance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmitanceExists(id))
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

        // POST: api/Admitances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admitance>> PostAdmitance(Admitance admitance)
        {
            _context.Admitance.Add(admitance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmitance", new { id = admitance.admit_id }, admitance);
        }

        // DELETE: api/Admitances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmitance(int id)
        {
            var admitance = await _context.Admitance.FindAsync(id);
            if (admitance == null)
            {
                return NotFound();
            }

            _context.Admitance.Remove(admitance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmitanceExists(int id)
        {
            return _context.Admitance.Any(e => e.admit_id == id);
        }
    }
}
