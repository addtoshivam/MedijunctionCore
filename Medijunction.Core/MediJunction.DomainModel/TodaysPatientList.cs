using MediJunction.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediJunction.DomainModel
{
    [Table("TodaysPatientList")]
    public class TodaysPatientList : BaseEntity
    {
        [Key]
        public int PatientId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.Guid> ChampId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsConsulted { get; set; }
        public Nullable<System.Guid> DoctorId { get; set; }
        public Nullable<int> PreConsultId { get; set; }
        public Nullable<System.Guid> AppointmentId { get; set; }
        public Nullable<long> UserCouponId { get; set; }
    }
}
