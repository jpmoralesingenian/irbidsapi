using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IrbidsAPI.Models;

namespace IrbidsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttemptsController : ControllerBase
    {
        private readonly IrbidsAPIContext _context;

        public AttemptsController(IrbidsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Attempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attempt>>> GetAttempt()
        {
            return await _context.Attempt.ToListAsync();
        }

        // GET: api/Attempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attempt>> GetAttempt(int id)
        {
            var attempt = await _context.Attempt.FindAsync(id);

            if (attempt == null)
            {
                return NotFound();
            }

            return attempt;
        }

        // PUT: api/Attempts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttempt(int id, Attempt attempt)
        {
            if (id != attempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(attempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttemptExists(id))
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

        // POST: api/Attempts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Attempt>> PostAttempt(Attempt attempt)
        {
            //Check if the user exists, if not, create her
            //if(_context.User.Where(x => x.Ani == ))
            _context.Attempt.Add(attempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttempt", new { id = attempt.Id }, attempt);
        }

        // DELETE: api/Attempts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attempt>> DeleteAttempt(int id)
        {
            var attempt = await _context.Attempt.FindAsync(id);
            if (attempt == null)
            {
                return NotFound();
            }

            _context.Attempt.Remove(attempt);
            await _context.SaveChangesAsync();

            return attempt;
        }

        private bool AttemptExists(int id)
        {
            return _context.Attempt.Any(e => e.Id == id);
        }
    }
}
