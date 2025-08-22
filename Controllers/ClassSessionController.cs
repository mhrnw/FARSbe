using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FARSbe.Data;
using FARSbe.Models;

namespace FARSbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSessionController : ControllerBase
    {
        private readonly FarsDbContext _context;

        public ClassSessionController(FarsDbContext context)
        {
            _context = context;
        }

        // GET: api/classsession
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClassSessions()
        {
            return await _context.Classes.ToListAsync();
        }

        // GET: api/classsession/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassSession(int id)
        {
            var session = await _context.Classes.FindAsync(id);

            if (session == null)
                return NotFound();

            return session;
        }

        // POST: api/classsession
        [HttpPost]
        public async Task<ActionResult<Class>> PostClassSession(Class session)
        {
            _context.Classes.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassSession), new { id = session.Id }, session);
        }

        // PUT: api/classsession/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassSession(int id, Class session)
        {
            if (id != session.Id)
                return BadRequest();

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Classes.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/classsession/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassSession(int id)
        {
            var session = await _context.Classes.FindAsync(id);
            if (session == null)
                return NotFound();

            _context.Classes.Remove(session);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}