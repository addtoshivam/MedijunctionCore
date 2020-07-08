using MediJunction.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediJunction.DomainModel
{
    public class TodaysPatientImage : BaseEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ImageURL { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
