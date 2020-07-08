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

        public DbSet<AppointmentMaster> AppointmentMasters  { get; set; }
        public DbSet<TodaysPatientList> TodaysPatientLists { get; set; }
        public DbSet<TodaysPatientImage> TodaysPatientImages { get; set; }
        public DbSet<PreConsultation> PreConsultations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }


}
