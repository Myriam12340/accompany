using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accompany_consulting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Accompany_consulting.Data;
using System.Threading;

namespace Accompany_consulting.Models
{
    public class MiseAJourSoldeService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private System.Threading.Timer _timer;

        public MiseAJourSoldeService(IServiceProvider services)
        {
            _services = services;
        }

        // Cette méthode est appelée lors du démarrage du service hébergé.
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Calculez le temps jusqu'au prochain premier jour du mois
            var maintenant = DateTime.UtcNow;
            var prochainPremierJourDuMois = new DateTime(maintenant.Year, maintenant.Month, 1).AddMonths(1);
            var tempsRestant = prochainPremierJourDuMois - maintenant;

            // Créez le Timer avec la période jusqu'au prochain premier jour du mois
            _timer = new System.Threading.Timer(async (state) => await HandleTimerAsync(), null, tempsRestant, TimeSpan.FromMilliseconds(-1));

            await Task.CompletedTask;
        }

        private async Task HandleTimerAsync()
        {
            using (var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ConsultantContext>();

                var consultants = await dbContext.Consultants.ToListAsync();
                foreach (var consultant in consultants)
                {
                    consultant.SoldeConge += 2;
                }

                await dbContext.SaveChangesAsync();
            }

            // Calculez le temps jusqu'au prochain premier jour du mois suivant
            var maintenant = DateTime.UtcNow;
            var prochainPremierJourDuMois = new DateTime(maintenant.Year, maintenant.Month, 1).AddMonths(1);
            var tempsRestant = prochainPremierJourDuMois - maintenant;

            // Mettez à jour la période du Timer pour le prochain mois
            _timer.Change(tempsRestant, TimeSpan.FromMilliseconds(-1));
        }
    }
}
