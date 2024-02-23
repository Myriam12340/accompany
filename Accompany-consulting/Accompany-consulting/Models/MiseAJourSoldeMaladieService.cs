using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accompany_consulting.Data;
using Microsoft.EntityFrameworkCore;

namespace Accompany_consulting.Models
{
    public class MiseAJourSoldeMaladieService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<MiseAJourSoldeMaladieService> _logger;
        private DateTime _derniereMiseAJour;

        public MiseAJourSoldeMaladieService(IServiceProvider services, ILogger<MiseAJourSoldeMaladieService> logger)
        {
            _services = services;
            _logger = logger;
            _derniereMiseAJour = DateTime.UtcNow;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Le service MiseAJourSoldeMaladieService démarre.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var maintenant = DateTime.UtcNow;

                if (maintenant.Year > _derniereMiseAJour.Year)
                {
                    using (var scope = _services.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ConsultantContext>();

                        var consultants = await dbContext.Consultants.ToListAsync();
                        foreach (var consultant in consultants)
                        {
                            consultant.SoldeMaladie += 3;
                        }

                        await dbContext.SaveChangesAsync();

                        _derniereMiseAJour = maintenant;

                        _logger.LogInformation("SoldeMaladie mis à jour pour tous les consultants.");
                    }
                }

                // Calculer le délai jusqu'à l'année suivante
                var anneeSuivante = maintenant.AddYears(1);
                var premierJourAnneeSuivante = new DateTime(anneeSuivante.Year, 1, 1);
                var delai = premierJourAnneeSuivante - maintenant;


                



                // Attendre jusqu'au premier jour de l'année suivante
                await Task.Delay(delai.Seconds, stoppingToken);
                // ...

            }

        }
    }
}
