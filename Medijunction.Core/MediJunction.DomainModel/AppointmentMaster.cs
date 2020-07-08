using MediJunction.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediJunction.DomainModel
{
    [Table("AppointmentMaster")]
    public class AppointmentMaster : BaseEntity
    {
        [Key]
        public System.Guid AppointmentId { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> DoctorId { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string CaseNo { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Attachment { get; set; }
        public string PrescriptionType { get; set; }
        public string Notes { get; set; }
        public Nullable<double> Fees { get; set; }
        public Nullable<double> InjectionFees { get; set; }
        public Nullable<double> Discount { get; set; }
        public string PrescriptionComingFrom { get; set; }
        public string Laboratory { get; set; }
        public string Diagnostic { get; set; }
        public string Symptoms { get; set; }
        public Nullable<int> PatientAge { get; set; }
        public Nullable<double> SystolicBP { get; set; }
        public Nullable<double> DiastolicBP { get; set; }
        public string CholesterolLDL { get; set; }
        public string CholesterolHDL { get; set; }
        public Nullable<double> Temp { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> Sugar { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<System.Guid> ParentAppointmentId { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<System.DateTime> FollowUpDate { get; set; }
    }
}
