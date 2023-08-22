using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accompany_consulting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Accompany_consulting.Data;

namespace Accompany_consulting.Models
{
    public class MiseAJourSoldeMaladieService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public MiseAJourSoldeMaladieService(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ConsultantContext>(); // Remplacez VotreDbContext par votre contexte de base de données

                    var consultants = await dbContext.Consultants.ToListAsync();
                    foreach (var consultant in consultants)
                    {
                        consultant.SoldeMaladie += 3; // Ajoutez la mise à jour du solde de maladie ici
                    }

                    await dbContext.SaveChangesAsync();
                }

                // Attendre jusqu'au 1er jour de l'année suivante
                var now = DateTime.UtcNow;
                var nextYear = now.AddYears(1);
                var firstDayOfNextYear = new DateTime(nextYear.Year, 1, 1);
                var delay = firstDayOfNextYear - now;

                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
