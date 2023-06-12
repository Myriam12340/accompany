using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accompany_consulting.Data;
using Accompany_consulting.Models;
using Accompany_consulting.Migrations;

namespace Accompany_consulting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongesController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public CongesController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/Conges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conge>>> GetConge()
        {
            return await _context.Conge.ToListAsync();
        }

        // GET: api/Conges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conge>> GetConge(int id)
        {
            var conge = await _context.Conge.FindAsync(id);

            if (conge == null)
            {
                return NotFound();
            }

            return conge;
        }

        // PUT: api/Conges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConge(int id, Conge conge)
        {
            if (id != conge.Id)
            {
                return BadRequest();
            }

            _context.Entry(conge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongeExists(id))
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

        // POST: api/Conges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conge>> PostConge(Conge conge)
        {
            conge.DateDemande = DateTime.Now;
            _context.Conge.Add(conge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConge", new { id = conge.Id }, conge);
        }

        // DELETE: api/Conges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConge(int id)
        {
            var conge = await _context.Conge.FindAsync(id);
            if (conge == null)
            {
                return NotFound();
            }

            _context.Conge.Remove(conge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongeExists(int id)
        {
            return _context.Conge.Any(e => e.Id == id);
        }


        // GET: api/Conges/GetCongeParDemandeur/5
        [HttpGet("GetCongeParDemandeur/{demandeurId}")]
        public async Task<ActionResult<IEnumerable<Conge>>> GetCongeParDemandeur(int demandeurId)
        {
            var conges = await _context.Conge.Where(c => c.Demandeur == demandeurId).ToListAsync();

            if (conges == null)
            {
                return NotFound();
            }

            return conges;
        }
        // GET: api/Conges/GetCongeParValidateur/5
        [HttpGet("GetCongeParValidateur/{validateurId}")]
        public async Task<ActionResult<IEnumerable<Conge>>> GetCongeParValidateur(int validateurId)
        {
            var conges = await _context.Conge.Where(c => c.Validateur == validateurId).ToListAsync();

            if (conges == null)
            {
                return NotFound();
            }

            return conges;
        }




        [HttpPut("etat/{id}/{etatmodifier}")]
        public IActionResult UpdateCongeEtat(int id,  string etatmodifier)
        {
            // Retrieve the congé from the database based on the provided id
            var conge = _context.Conge.FirstOrDefault(c => c.Id == id);

            // If the congé is not found, return a not found response
            if (conge == null)
            {
                return NotFound();
            }

            // Update the etat of the congé
            conge.etat = etatmodifier;

            // Save the changes to the database
            _context.SaveChanges();

            // Return a success response
            return Ok();
        }




    }
}
