using Accompany_consulting.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Accompany_consulting.Models
{
    public interface IConsultantCongeService
    {
        Task UpdateSoldeCongeAsync();
    }

    public class ConsultantCongeService : IConsultantCongeService
    {
         private readonly ConsultantContext _context;

        public ConsultantCongeService(ConsultantContext dbContext)
        {
            _context = dbContext;
        }

        public async Task UpdateSoldeCongeAsync()
        {
            // Obtenez la liste des consultants depuis la base de données
            var consultants = await  _context.Consultants.ToListAsync();

            foreach (var consultant in consultants)
            {
                // Mettez à jour le solde de congé du consultant
                consultant.SoldeConge += 2;
                
            }

            // Enregistrez les modifications dans la base de données
            await _context.SaveChangesAsync();
        }


        public async Task UpdateSoldemaladieAsync()
        {
            // Obtenez la liste des consultants depuis la base de données
            var consultants = await _context.Consultants.ToListAsync();

            foreach (var consultant in consultants)
            {
                // Mettez à jour le solde de congé du consultant
                consultant.SoldeMaladie += 3;

            }

            // Enregistrez les modifications dans la base de données
            await _context.SaveChangesAsync();
        }
    }

}
