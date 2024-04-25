﻿using LabPreTest.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LabPreTest.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // for each database entity you need create a DbSet
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Medician> Medicians { get; set; }
         
        public DbSet<Patient> Patients {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => new { x.StateId, x.Name }).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(x => x.DocumentId).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<Medician>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Medician>().HasIndex(x => x.DocumentId).IsUnique();
            modelBuilder.Entity<Medician>().HasIndex(x => x.UserName).IsUnique();
            DisableCascadingDelete(modelBuilder);
        }
        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}