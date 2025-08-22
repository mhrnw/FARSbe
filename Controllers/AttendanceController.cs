using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FARSbe.Data;
using FARSbe.Models;

namespace FARSbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly FarsDbContext _context;

        public AttendanceController(FarsDbContext context)
        {
            _context = context;
        }

        // GET: api/attendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance()
        {
            return await _context.Attendances.ToListAsync();
        }

        // GET: api/attendance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceRecord(int id)
        {
            var record = await _context.Attendances.FindAsync(id);

            if (record == null)
                return NotFound();

            return record;
        }

        // POST: api/attendance
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance record)
        {
            _context.Attendances.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendanceRecord), new { id = record.Id }, record);
        }

        // PUT: api/attendance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(int id, Attendance record)
        {
            if (id != record.Id)
                return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Attendances.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/attendance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var record = await _context.Attendances.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.Attendances.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
