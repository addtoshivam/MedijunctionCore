using MediJunction.ServiceModel;
using MediJunction.ServiceModel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediJunction.Process.Contracts
{
    public interface IUserProcess
    {
        ReconsultationResponse Reconsultation(ReConsultationRequest reconsultationRequest);
    }
}
