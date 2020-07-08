using MediJunction.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediJunction.DomainModel
{
    [Table("PreConsultation")]
    public class PreConsultation : BaseEntity
    {
        [Key]
        public int PreConsultId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Notes { get; set; }
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
    }
}
