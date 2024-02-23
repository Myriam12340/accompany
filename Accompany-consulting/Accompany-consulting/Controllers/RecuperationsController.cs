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
    public class RecuperationsController : ControllerBase
    {
        private readonly ConsultantContext _context;

        public RecuperationsController(ConsultantContext context)
        {
            _context = context;
        }

        // GET: api/Recuperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recuperation>>> GetRecuperation()
        {
            return await _context.Recuperation.ToListAsync();
        }

        // GET: api/Recuperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recuperation>> GetRecuperation(int id)
        {
            var recuperation = await _context.Recuperation.FindAsync(id);

            if (recuperation == null)
            {
                return NotFound();
            }

            return recuperation;
        }

        // PUT: api/Recuperations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecuperation(int id, Recuperation recuperation)
        {
            if (id != recuperation.Id)
            {
                return BadRequest();
            }

            _context.Entry(recuperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecuperationExists(id))
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

        // POST: api/Recuperations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recuperation>> PostRecuperation(Recuperation recuperation)
        {
            recuperation.DateDemande = DateTime.Now; // Définir la propriété DateDemande sur la date système

            _context.Recuperation.Add(recuperation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecuperation", new { id = recuperation.Id }, recuperation);
        }


        // DELETE: api/Recuperations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecuperation(int id)
        {
            var recuperation = await _context.Recuperation.FindAsync(id);
            if (recuperation == null)
            {
                return NotFound();
            }

            _context.Recuperation.Remove(recuperation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecuperationExists(int id)
        {
            return _context.Recuperation.Any(e => e.Id == id);
        }


      
        [HttpGet("GetRecupParValidateur/{validateurId}")]
        public async Task<ActionResult<IEnumerable<Recuperation>>> GetRecupParValidateur(int validateurId)
        {
            var recups = await _context.Recuperation.Where(c => c.Validateur == validateurId).ToListAsync();

            if (recups == null)
            {
                return NotFound();
            }

            return recups;
        }







        [HttpPut("etat/{id}/{etatmodifier}/duree/{duree}")]
        public IActionResult UpdateCongeEtat(int id, string etatmodifier,int duree)
        {
            // Retrieve the congé from the database based on the provided id
            var Recup = _context.Recuperation.FirstOrDefault(c => c.Id == id);

            // If the congé is not found, return a not found response
            if (Recup == null)
            {
                return NotFound();
            }

            // Update the etat of the congé
            Recup.etat = etatmodifier;
            Recup.duree = duree;

            // Save the changes to the database
            _context.SaveChanges();

            // Return a success response
            return Ok();
        }


        [HttpGet("grouped-by-numero")]
        public IActionResult GetRecuperationsGroupedByNumero()
        {
            var recuperationsOfTypeGroupe = _context.Recuperation
                .Where(r => r.Type == "groupe") // Assurez-vous que cette condition correspond exactement à la propriété dans votre modèle
                .ToList();

            var groupedRecuperations = recuperationsOfTypeGroupe
                .GroupBy(r => r.numeroDemande)
                .Select(group => new
                {
                    NumeroDemande = group.Key,
                    Manager = group.First().manager, // Assurez-vous que Manager est une propriété valide dans votre modèle

                    DateDemande = group.First().DateDemande, // Assurez-vous que Manager est une propriété valide dans votre modèle
                     

                    Demandes = group.ToList()
                })
                .ToList();

            return Ok(groupedRecuperations);
        }


        [HttpGet("GetRecupParNumeroDemande/{numeroDemande}")]
        public async Task<ActionResult<IEnumerable<Recuperation>>> GetRecupParNumeroDemande(int numeroDemande)
        {
            var recups = await _context.Recuperation.Where(c => c.numeroDemande == numeroDemande).ToListAsync();

            if (recups == null || recups.Count == 0)
            {
                return NotFound();
            }

            return recups;
        }





    }
}
