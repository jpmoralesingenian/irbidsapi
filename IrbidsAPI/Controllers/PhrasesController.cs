using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IrbidsAPI.Models;

namespace IrbidsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase
    {
        private readonly IrbidsAPIContext _context;
        public PhrasesController(IrbidsAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Word>> Random(string Ani)
        {
            int id = 1447 + new Random().Next() % (_context.Word.Count());
            var word =  await _context.Word.FindAsync(id);
            while(word==null)
            {
                word = await _context.Word.FindAsync(id);
            }
            return word;
        }
    }
}
