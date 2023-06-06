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
    public class EvaluationsController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public EvaluationsController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/Evaluations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluation()
        {
            return await _context.Evaluation.ToListAsync();
        }

        // GET: api/Evaluations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluation>> GetEvaluation(int id)
        {
            var evaluation = await _context.Evaluation.FindAsync(id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return evaluation;
        }

        // PUT: api/Evaluations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluation(int id, Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return BadRequest();
            }

            _context.Entry(evaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(id))
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

        // POST: api/Evaluations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation)
        {
            evaluation.Date_evaluation = DateTime.Now; // Set the Date_evaluation to the current system date
            _context.Evaluation.Add(evaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluation", new { id = evaluation.Id }, evaluation);
        }

        // DELETE: api/Evaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            _context.Evaluation.Remove(evaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluation.Any(e => e.Id == id);
        }

        [HttpGet("hr/{id}")]
        public async Task<ActionResult<double>> GetHRByEvaluationId(int id)
        {
            var evaluation = await _context.Evaluation.FindAsync(id);

            if (evaluation == null)
            {
                return NotFound();
            }

            var hrValue = evaluation.Hr; // Assuming the field name is "Hr" in the Evaluation model and it's of type double.

            return Ok(hrValue);
        }



        [HttpGet("email/{evaluationId}")]
        public async Task<ActionResult<string>> GetUserEmailByEvaluationId(int evaluationId)
        {
            var evaluation = await _context.Evaluation.FindAsync(evaluationId);

            if (evaluation == null)
            {
                return NotFound("Evaluation not found");
            }

            var userId = evaluation.Hr; // Assuming the foreign key to the User table is named "UserId" in the Evaluation model.

            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userEmail = user.Email;

            return Ok(userEmail);
        }









    }
}
