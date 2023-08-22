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
    public class MiseAJourSoldeService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public MiseAJourSoldeService(IServiceProvider services)
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
                        consultant.SoldeConge += 2;
                    }

                    await dbContext.SaveChangesAsync();
                }

                // Attendre jusqu'au 1er jour du mois suivant
                var now = DateTime.UtcNow;
                var nextMonth = now.AddMonths(1);
                var firstDayOfNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1);
                var delay = firstDayOfNextMonth - now;

                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
