using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Accompany_consulting.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Accompany_consulting.Models;

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using Microsoft.AspNet.Identity;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddHostedService<MiseAJourSoldeService>();
        services.AddHostedService<MiseAJourSoldeMaladieService>();


        services.AddDbContext<ConsultantContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConsultantContext")),
            ServiceLifetime.Scoped);



        services.AddIdentity<User, IdentityRole<int>>(options =>
        {
            // Configure password options
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;
        })
        .AddEntityFrameworkStores<ConsultantContext>()
        .AddDefaultTokenProviders()
        .AddRoles<IdentityRole<int>>(); // Ajoute la gestion des rôles

        // Configure other services
        services.AddControllersWithViews();


        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:60734", // Mettez ici l'URL de votre serveur d'authentification
                ValidAudience = "https://localhost:60734",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")) // Mettez ici votre clé secrète pour signer les jetons JWT
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AllAccess", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        });


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });

        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<int>>>();

            var roleManager1 = serviceScope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<int>>>();
            var roleManager2 = serviceScope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<int>>>();

            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                // Ajouter le rôle "Manager" s'il n'existe pas
                var role = new IdentityRole<int>
                {
                    Name = "Manager"
                };
                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Erreur lors de la création du rôle Manager.");
                }
            }


            if (!roleManager1.RoleExistsAsync("Admin").Result)
            {
                // Ajouter le rôle "Manager" s'il n'existe pas
                var role = new IdentityRole<int>
                {
                    Name = "Admin"
                };
                var result = roleManager1.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Erreur lors de la création du rôle Admin.");
                }
            }

            if (!roleManager2.RoleExistsAsync("Consultant").Result)
            {
                // Ajouter le rôle "Manager" s'il n'existe pas
                var role = new IdentityRole<int>
                {
                    Name = "Consultant"
                };
                var result = roleManager2.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Erreur lors de la création du rôle Consultant.");
                }
            }
        }
    

}
}
