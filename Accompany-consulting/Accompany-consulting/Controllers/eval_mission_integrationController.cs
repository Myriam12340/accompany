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
    public class eval_mission_integrationController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public eval_mission_integrationController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/eval_mission_integration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eval_mission_integration>>> Geteval_Mission_Integrations()
        {
            return await _context.eval_Mission_Integrations.ToListAsync();
        }

        // GET: api/eval_mission_integration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<eval_mission_integration>> Geteval_mission_integration(int id)
        {
            var eval_mission_integration = await _context.eval_Mission_Integrations.FindAsync(id);

            if (eval_mission_integration == null)
            {
                return NotFound();
            }

            return eval_mission_integration;
        }

        // PUT: api/eval_mission_integration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puteval_mission_integration(int id, eval_mission_integration eval_mission_integration)
        {
            if (id != eval_mission_integration.Id)
            {
                return BadRequest();
            }

            _context.Entry(eval_mission_integration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eval_mission_integrationExists(id))
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

        // POST: api/eval_mission_integration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<eval_mission_integration>> Posteval_mission_integration(eval_mission_integration eval_mission_integration)
        {
            _context.eval_Mission_Integrations.Add(eval_mission_integration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Geteval_mission_integration", new { id = eval_mission_integration.Id }, eval_mission_integration);
        }

        // DELETE: api/eval_mission_integration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteeval_mission_integration(int id)
        {
            var eval_mission_integration = await _context.eval_Mission_Integrations.FindAsync(id);
            if (eval_mission_integration == null)
            {
                return NotFound();
            }

            _context.eval_Mission_Integrations.Remove(eval_mission_integration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool eval_mission_integrationExists(int id)
        {
            return _context.eval_Mission_Integrations.Any(e => e.Id == id);
        }



        // GET: api/eval_mission_integration/mission/{missionId}
        [HttpGet("mission/{missionId}")]
        public async Task<ActionResult<eval_mission_integration>> GetEvalByMissionId(int missionId)
        {
            var evalMissionIntegration = await _context.eval_Mission_Integrations
                .FirstOrDefaultAsync(eval => eval.Mission == missionId);

            if (evalMissionIntegration == null)
            {
                return NotFound();
            }

            return evalMissionIntegration;
        }


        [HttpGet("consultant/{consultantId}")]
        public async Task<ActionResult<List<eval_mission_integration>>> GetEvalByConsultantId(int consultantId)
        {
            var evalMissionIntegrations = await _context.eval_Mission_Integrations
                .Where(eval => eval.Consultant == consultantId)
                .ToListAsync();

            if (evalMissionIntegrations == null || evalMissionIntegrations.Count == 0)
            {
                return NotFound();
            }

            return evalMissionIntegrations;
        }




        [HttpGet("manager/{managerId}")]
        public async Task<ActionResult<List<eval_mission_integration>>> GetEvalByManagerId(int managerId)
        {
            var evalMissionIntegrations = await _context.eval_Mission_Integrations
                .Where(eval => eval.Manager == managerId)
                .ToListAsync();

            if (evalMissionIntegrations == null || evalMissionIntegrations.Count == 0)
            {
                return NotFound();
            }

            return evalMissionIntegrations;
        }



        [HttpGet("list/{consultantId}/evaluation/{evaluationId}")]
        public async Task<ActionResult<List<eval_mission_integration>>> GetEvalByConsultantAndEvaluation(int consultantId, int evaluationId)
        {
            var evalMissionIntegrations = await _context.eval_Mission_Integrations
                .Where(eval => eval.Consultant == consultantId && eval.evaluation == evaluationId)
                .ToListAsync();


            return evalMissionIntegrations;
        }
    }
}
