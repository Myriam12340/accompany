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
    public class MissionsController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public MissionsController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/Missions/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMission()
        {
            return await _context.Mission.ToListAsync();
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMission(int id)
        {
            var mission = await _context.Mission.FindAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        // PUT: api/Missions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(int id, Mission mission)
        {
            if (id != mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Missions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(Mission mission)
        {
            _context.Mission.Add(mission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMission", new { id = mission.Id }, mission);
        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var mission = await _context.Mission.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Mission.Remove(mission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionExists(int id)
        {
            return _context.Mission.Any(e => e.Id == id);
        }


        //get list evaluation evaluation  a faire 
        [HttpGet("manager/{manager}")]
        public async Task<List<Mission>> GetmissionsBymanager(int manager)
        {
            var missions = await _context.Mission.Where(e => e.Manager == manager).ToListAsync();
            return missions;
        }



        [HttpGet("titre/{titre}")]
        public async Task<List<Mission>> GetmissionsBytitre(string titre)
        {
            var missions = await _context.Mission.Where(e => e.titre == titre).ToListAsync();
            return missions;
        }

        [HttpGet("consultant/{consultantId}")]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissionsByConsultant(int consultantId)
        {
            var missions = await _context.Mission.Where(m => m.Consultant == consultantId).ToListAsync();

            if (missions == null || missions.Count == 0)
            {
                return NotFound();
            }

            return missions;
        }


    }


}
