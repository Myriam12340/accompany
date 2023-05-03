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
    public class EntretientsController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public EntretientsController(ConsultantContext context)
        {
            _context = context;
        }
        //get historique entretien
        [HttpGet("recruteur/{recruteur}")]
        public async Task<List<Entretient>> GetEntretientsByRecruteur(int recruteur)
        {
            var entretients = await _context.entretien.Where(e => e.Recruteur == recruteur).ToListAsync();
            return entretients;
        }


        //get list des entretient a faire 
        [HttpGet("recruteursuivant/{recruteursuivant}")]
        public async Task<List<Entretient>> GetEntretientsByRecruteursuivant(int recruteursuivant)
        {
            var entretients = await _context.entretien.Where(e => e.RecruteurSuivant == recruteursuivant).ToListAsync();
            return entretients;
        }

        //get entretien par candidat
        [HttpGet("candidat/{candidat}")]
        public async Task<List<Entretient>> GetEntretientsByCandidat(int candidat)
        {
            var entretients = await _context.entretien.Where(e => e.Candidat == candidat).ToListAsync();
            return entretients;
        }



        //get candidat 
        [HttpGet("getcandidat/{id}")]
        public async Task<ActionResult<Candidat>> GetCandidat(int id)
        {
            var candidat = await _context.candidat.FirstOrDefaultAsync(e => e.Id == id);
            if (candidat == null)
            {
                return NotFound();
            }
            return Ok(candidat);
        }


        // GET: api/Entretients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entretient>>> Getentretien()
        {
            return await _context.entretien.ToListAsync();
        }

        // GET: api/Entretients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entretient>> GetEntretient(int id)
        {
            var entretient = await _context.entretien.FindAsync(id);

            if (entretient == null)
            {
                return NotFound();
            }

            return entretient;
        }

        // PUT: api/Entretients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntretient(int id, Entretient entretient)
        {
            if (id != entretient.Id)
            {
                return BadRequest();
            }

            _context.Entry(entretient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntretientExists(id))
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

        // POST: api/Entretients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entretient>> PostEntretient(EntretientViewModel viewModel)
        {
            if (viewModel == null || viewModel.Entretient == null)
            {
                return BadRequest("Invalid request body");
            }

            // add the Candidat and Entretient objects to the database
            _context.candidat.Add(viewModel.Candidat);
            await _context.SaveChangesAsync(); // save changes to generate ID for Candidat

            viewModel.Entretient.Candidat = viewModel.Candidat.Id; // update Entretient.Candidat with the ID of the newly created Candidat
            _context.entretien.Add(viewModel.Entretient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntretient", new { id = viewModel.Entretient.Id }, viewModel.Entretient);
        }




        // DELETE: api/Entretients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntretient(int id)
        {
            var entretient = await _context.entretien.FindAsync(id);
            if (entretient == null)
            {
                return NotFound();
            }

            _context.entretien.Remove(entretient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntretientExists(int id)
        {
            return _context.entretien.Any(e => e.Id == id);
        }
        public class EntretientViewModel
        {
            public Candidat Candidat { get; set; }
            public Entretient Entretient { get; set; }
        }
    }
}
