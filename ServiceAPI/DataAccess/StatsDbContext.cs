using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAPI.Models;

namespace ServiceAPI.DataAccess
{
    public class StatsDbContext : DbContext
    {
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalData> HospitalStats { get; set; }

        public StatsDbContext(DbContextOptions<StatsDbContext> options) : base (options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Hospital> hospitals = new List<Hospital>()
            {
                new Hospital() {Id = 1, Name = "National Institute of Infectious Diseases"},
                new Hospital() {Id = 2, Name = "National Hospital Sri Lanka"},
                new Hospital() {Id = 3, Name = "TH - Ragama"},
                new Hospital() {Id = 4, Name = "TH - Karapitiya"},
                new Hospital() {Id = 5, Name = "TH - Anuradhapura"},
                new Hospital() {Id = 6, Name = "TH - Kurunegala"},
                new Hospital() {Id = 7, Name = "TH- Jaffna"},
                new Hospital() {Id = 8, Name = "National Hospital Kandy"},
                new Hospital() {Id = 9, Name = "TH – Batticaloa"},
                new Hospital() {Id = 10, Name = "DGH- Gampaha"},
                new Hospital() {Id = 11, Name = "DGH – Negombo"},
                new Hospital() {Id = 12, Name = "TH – Rathnapura"},
                new Hospital() {Id = 13, Name = "PGH – Badulla"},
                new Hospital() {Id = 14, Name = "LRH"},
                new Hospital() {Id = 15, Name = "DMH"},
                new Hospital() {Id = 16, Name = "DGH – Polonnaruwa"},
                new Hospital() {Id = 17, Name = "TH - Kalubowila"}
            };
           
            

            modelBuilder.Entity<Hospital>().HasData(hospitals);

        }
    }
}
