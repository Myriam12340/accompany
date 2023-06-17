using Accompany_consulting.Data;
using Accompany_consulting.Migrations;
using Accompany_consulting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accompany_consulting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly ConsultantContext _context;
        private readonly UserManager<User> _userManager;

        public ConsultantsController(UserManager<User> userManager, ConsultantContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Consultants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultant()
        {
            return await _context.Consultants.ToListAsync();
        }

        // GET: api/Consultants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultant>> GetConsultant(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);

            if (consultant == null)
            {
                return NotFound();
            }

            return consultant;
        }

        // PUT:c5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
   
        public async Task<IActionResult> PutConsultant(int id, Consultant consultant)
        {
            if (id != consultant.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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






        // POST: api/Consultants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<Consultant>> PostConsultant(Consultant consultant)
        {
            consultant.SoldeConge = 2;
            consultant.SoldeMaladie = 3;

            _context.Consultants.Add(consultant);

            // Création d'un nouvel utilisateur avec le rôle "consultant"
           
            var password = "123456789";

            // Utilisation du gestionnaire de mots de passe pour hacher le mot de passe
            var existingEmailUser = await _userManager.FindByEmailAsync(consultant.Mail);
            if (existingEmailUser != null)
            {
                return BadRequest("Email already exists.");
            }



            var user = new User { Email = consultant.Mail, UserName = consultant.Nom + consultant.Prenom, NormalizedEmail = consultant.Mail, Role = "consultant" };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }



            return CreatedAtAction("GetConsultant", new { id = consultant.Id }, consultant);
        }




        // DELETE: api/Consultants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultants.Any(e => e.Id == id);
        }
        // PUT: api/Consultants/5/contract
        [HttpPut("contract/{id}/{newcontrat}")]
        public async Task<IActionResult> UpdateContract(int id, string newContract)

        {
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            consultant.Contrat = newContract;
            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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


        [HttpGet("email/{email}")]
        public async Task<ActionResult<Consultant>> GetConsultantByEmail(string email)
        {
            var consultant = await _context.Consultants.FirstOrDefaultAsync(c => c.Mail == email);

            if (consultant == null)
            {
                return NotFound(); // Renvoie une réponse 404 si le consultant n'est pas trouvé
            }

            return Ok(consultant); // Renvoie le consultant trouvé avec une réponse 200
        }





        [HttpPut("etat/{id}/{etatmodifier}")]
        public IActionResult UpdateContrat(int id, string etatmodifier)
        {
            // Retrieve the congé from the database based on the provided id
            var conge = _context.Consultants.FirstOrDefault(c => c.Id == id);

            // If the congé is not found, return a not found response
            if (conge == null)
            {
                return NotFound();
            }

            // Update the etat of the congé
            conge.Contrat = etatmodifier;

            // Save the changes to the database
            _context.SaveChanges();

            // Return a success response
            return Ok();
        }












    }
}
