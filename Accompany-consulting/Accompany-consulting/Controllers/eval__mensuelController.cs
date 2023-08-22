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
    public class eval__mensuelController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public eval__mensuelController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/eval__mensuel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eval__mensuel>>> Geteval__mensuel()
        {
            return await _context.eval__mensuel.ToListAsync();
        }

        // GET: api/eval__mensuel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<eval__mensuel>> Geteval__mensuel(int id)
        {
            var eval__mensuel = await _context.eval__mensuel.FindAsync(id);

            if (eval__mensuel == null)
            {
                return NotFound();
            }

            return eval__mensuel;
        }

        // PUT: api/eval__mensuel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puteval__mensuel(int id, eval__mensuel eval__mensuel)
        {
            if (id != eval__mensuel.Id)
            {
                return BadRequest();
            }

            _context.Entry(eval__mensuel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eval__mensuelExists(id))
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

        // POST: api/eval__mensuel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<eval__mensuel>> Posteval__mensuel(eval__mensuel eval__mensuel)
        {
            _context.eval__mensuel.Add(eval__mensuel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Geteval__mensuel", new { id = eval__mensuel.Id }, eval__mensuel);
        }

        // DELETE: api/eval__mensuel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteeval__mensuel(int id)
        {
            var eval__mensuel = await _context.eval__mensuel.FindAsync(id);
            if (eval__mensuel == null)
            {
                return NotFound();
            }

            _context.eval__mensuel.Remove(eval__mensuel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool eval__mensuelExists(int id)
        {
            return _context.eval__mensuel.Any(e => e.Id == id);
        }


        [HttpGet("mission/{missionId}/consultant/{consultantId}")]
        public async Task<ActionResult<List<eval__mensuel>>> GetEvaluationsByMissionAndConsultant(int missionId, int consultantId)
        {
            var evaluations = await _context.eval__mensuel
                .Where(e => e.Mission == missionId && e.Consultant == consultantId)
                .ToListAsync();

            return evaluations;
        }
        [HttpGet("consultantEVL/{consultantId}")]
        public async Task<ActionResult<List<eval__mensuel>>> GetEvaluationsByConsultant(int consultantId)
        {
            var evaluations = await _context.eval__mensuel
                .Where(e => e.Consultant == consultantId)
                .ToListAsync();

            return evaluations;
        }


        [HttpGet("consultant-ids-with-evals")]
public async Task<ActionResult<List<int>>> GetConsultantIdsWithEvaluations()
{
    var consultantIdsWithEvals = await _context.eval__mensuel
        .Select(e => e.Consultant)
        .Distinct()
        .ToListAsync();

    return consultantIdsWithEvals;
}

      



    }
}
