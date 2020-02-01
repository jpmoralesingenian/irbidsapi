using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IrbidsAPI.Models;

namespace IrbidsAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private static readonly Watson Watson = new Watson();
        private readonly IrbidsAPIContext _context;
        public GradesController(IrbidsAPIContext context)
        {
            _context = context;
        }
        // POST: api/Grades
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            //Check if the user exists
            User user = _context.User.Where(x => x.Ani == grade.Ani).FirstOrDefault();
            if(user==null)
            {
                user = new User();
                user.Ani = grade.Ani;
                user.AttemptCount = 0;
                _context.User.Add(user);
            } 
            Word word = _context.Word.Find(grade.WordId);
            Attempt attempt = new Attempt();
            attempt.Word = word;
            attempt.RecordedURL = grade.RecordedURL;
            attempt.User = user;
            attempt.Created = DateTime.Now;
            attempt.Confidence = await Watson.RecognizeAsync(attempt);
            user.Score = (user.Score * user.AttemptCount + attempt.Confidence) / (user.AttemptCount + 1);
            user.AttemptCount++;
            _context.Attempt.Add(attempt);
            await _context.SaveChangesAsync();
            //Create the attempt
            grade.Ani = attempt.Confidence.ToString();
            return grade;
        }
    }
}
