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
    public class WordsController : ControllerBase
    {
        private readonly IrbidsAPIContext _context;

        public WordsController(IrbidsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWord(string Ani)
        {
            if(String.IsNullOrWhiteSpace(Ani)) return await _context.Word.ToListAsync();            
            return await GetRandomWord(Ani);
            
        }

        private async Task<ActionResult<IEnumerable<Word>>> GetRandomWord(string Ani)
        {
            int id = 1447 + new Random().Next() % (_context.Word.Count());
            return await _context.Word.Where(e => e.Id == id).ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
            var word = await _context.Word.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Word.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            var word = await _context.Word.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Word.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(int id)
        {
            return _context.Word.Any(e => e.Id == id);
        }
    }
}
