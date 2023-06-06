using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accompany_consulting.Data;
using Accompany_consulting.Models;

namespace Accompany_consulting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eval_competanceController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public eval_competanceController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/eval_competance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eval_competance>>> Geteval_competance()
        {
            return await _context.eval_competance.ToListAsync();
        }

        // GET: api/eval_competance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<eval_competance>> Geteval_competance(int id)
        {
            var eval_competance = await _context.eval_competance.FindAsync(id);

            if (eval_competance == null)
            {
                return NotFound();
            }

            return eval_competance;
        }

        // PUT: api/eval_competance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puteval_competance(int id, eval_competance eval_competance)
        {
            if (id != eval_competance.Id)
            {
                return BadRequest();
            }

            _context.Entry(eval_competance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eval_competanceExists(id))
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

        // POST: api/eval_competance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<eval_competance>> Posteval_competance(eval_competance eval_competance)
        {
            eval_competance.Date_evaluation = DateTime.Now;
            _context.eval_competance.Add(eval_competance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Geteval_competance", new { id = eval_competance.Id }, eval_competance);
        }


        





        // DELETE: api/eval_competance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteeval_competance(int id)
        {
            var eval_competance = await _context.eval_competance.FindAsync(id);
            if (eval_competance == null)
            {
                return NotFound();
            }

            _context.eval_competance.Remove(eval_competance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool eval_competanceExists(int id)
        {
            return _context.eval_competance.Any(e => e.Id == id);
        }
    }
}
