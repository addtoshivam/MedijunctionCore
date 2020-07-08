using Microsoft.EntityFrameworkCore;
using System;

namespace MediJunction.DomainModel
{
    public class MediJunctionContext : DbContext
    {
        public MediJunctionContext(DbContextOptions<MediJunctionContext> options)
            : base (options)
        {
        }

        public DbSet<AppointmentMaster> AppointmentMaster  { get; set; }
        public DbSet<TodaysPatientList> TodaysPatientList { get; set; }
        public DbSet<TodaysPatientImage> TodaysPatientImage { get; set; }
        public DbSet<PreConsultation> PreConsultation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }


}
