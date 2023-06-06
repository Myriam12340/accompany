using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Accompany_consulting.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Accompany_consulting.Migrations;

namespace Accompany_consulting.Data
{
    public class ConsultantContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ConsultantContext(DbContextOptions<ConsultantContext> options)
            : base(options)
        {
        }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Candidat> candidat { get; set; }
        public DbSet<Entretient> entretien { get; set; }

  public DbSet<Mission> Mission { get; set; }
  public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<eval_competance> eval_competance { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Configure other properties and relationships for User entity

        }

       



      
    }
}
