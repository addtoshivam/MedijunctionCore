using System;

namespace MediJunction.ServiceModel
{
    public class ReConsultationRequest
    {
        public Guid AppointmentId { get; set; }
        public Guid LoggedInUserId { get; set; }
    }
}
