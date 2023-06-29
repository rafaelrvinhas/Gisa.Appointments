using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.Data.Context
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PartnerService> PartnerServices { get; set; }
        public DbSet<PartnerSpecialty> PartnerSpecialties { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AssociatePlanInfo> AssociatePlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Specialty>().ToTable("Specialty");
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<Provider>().ToTable("Provider");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<AssociatePlanInfo>().ToTable("AssociatePlanInfo");

            modelBuilder.Entity<PartnerService>().ToTable("PartnerService");
            modelBuilder.Entity<PartnerService>().HasKey(ps => new { ps.PartnerId, ps.ServiceId });

            modelBuilder.Entity<PartnerService>()
                .HasOne(ps => ps.Partner)
                .WithMany(ps => ps.PartnerServices)
                .HasForeignKey(ps => ps.ServiceId);

            modelBuilder.Entity<PartnerService>()
                .HasOne(ps => ps.Service)
                .WithMany(ps => ps.PartnerServices)
                .HasForeignKey(ps => ps.PartnerId);

            modelBuilder.Entity<PartnerSpecialty>().ToTable("PartnerSpecialty");
            modelBuilder.Entity<PartnerSpecialty>().HasKey(ps => new { ps.PartnerId, ps.SpecialtyId });
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
