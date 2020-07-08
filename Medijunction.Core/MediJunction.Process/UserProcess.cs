using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using MediJunction.Process.Contracts;
using MediJunction.ServiceModel;
using MediJunction.ServiceModel.Response;
using System;

namespace MediJunction.Process
{
    public class UserProcess : IUserProcess
    {
        IDataFactory _dataFactory;
        public UserProcess(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public ReconsultationResponse Reconsultation(ReConsultationRequest reconsultationRequest)
        {
            if (reconsultationRequest != null)
            {
                string usertype = "REP";
                bool Isactive = true;
                var appointmentMaster = _dataFactory.GetData<IAppointmentMasterDAL>().Get(reconsultationRequest.AppointmentId);
                var todayspatientcheck = _dataFactory.GetData<ITodaysPatientListDAL>().FindBy(x => x.AppointmentId == reconsultationRequest.AppointmentId);
                if (appointmentMaster != null && todayspatientcheck == null && appointmentMaster.PatientId.HasValue)
                {
                    var todayspatient = _dataFactory.GetData<ITodaysPatientListDAL>().Get(appointmentMaster.PatientId.Value);
                    if (todayspatient != null)
                    {
                        PreConsultation preConsultation = new PreConsultation();
                        preConsultation.UserId = appointmentMaster.UserId;
                        preConsultation.PatientAge = appointmentMaster.PatientAge;
                        preConsultation.SystolicBP = appointmentMaster.SystolicBP;
                        preConsultation.DiastolicBP = appointmentMaster.DiastolicBP;
                        preConsultation.CholesterolHDL = appointmentMaster.CholesterolHDL;
                        preConsultation.CholesterolLDL = appointmentMaster.CholesterolLDL;
                        preConsultation.Temp = appointmentMaster.Temp;
                        preConsultation.Weight = appointmentMaster.Weight;
                        preConsultation.Sugar = appointmentMaster.Sugar;
                        preConsultation.Height = appointmentMaster.Height;
                        preConsultation.Notes = appointmentMaster.Laboratory;
                        preConsultation.CreatedBy = reconsultationRequest.LoggedInUserId;
                        preConsultation.CreatedDate = DateTime.Now;
                        _dataFactory.GetData<IPreconsulationDAL>().Add(preConsultation);

                        TodaysPatientList td = new TodaysPatientList();
                        td.UserId = todayspatient.UserId;
                        td.UserType = usertype;
                        td.FirstName = todayspatient.FirstName;
                        td.LastName = todayspatient.LastName;
                        td.Email = todayspatient.Email;
                        td.Mobile = todayspatient.Mobile;
                        td.IsActive = Isactive;
                        td.ChampId = reconsultationRequest.LoggedInUserId;
                        td.CreatedDate = DateTime.Now;
                        td.PreConsultId = preConsultation.PreConsultId;
                        td.AppointmentId = reconsultationRequest.AppointmentId;
                        _dataFactory.GetData<ITodaysPatientListDAL>().Add(td);

                        var todayspatientimages = _dataFactory.GetData<ITodaysPatientImageDAL>().FindBy(x => x.PatientId == appointmentMaster.PatientId);
                        foreach (var todayspatientimage in todayspatientimages)
                        {
                            TodaysPatientImage patientImage = new TodaysPatientImage();
                            patientImage.PatientId = td.PatientId;
                            patientImage.ImageURL = todayspatientimage.ImageURL;
                            patientImage.CreatedBy = reconsultationRequest.LoggedInUserId;
                            patientImage.CreatedDate = DateTime.Now;
                            _dataFactory.GetData<ITodaysPatientImageDAL>().Add(patientImage);
                        }
                        return new ReconsultationResponse { IsSuccessStatusCode = true, Message = "Reconsulatation done successfully", StatusCode = System.Net.HttpStatusCode.OK };
                        //response = Request.CreateResponse(HttpStatusCode.OK, new HttpResult { Message = "Reconsulatation done successfully", Response = true, Result = "Reconsulatation done successfully" });
                    }
                    //For this condition there is no response in Other API
                    return new ReconsultationResponse { IsSuccessStatusCode = false, Message = "No Patient linked with Appointment", StatusCode = System.Net.HttpStatusCode.NotFound };
                }
                else
                {
                    if (todayspatientcheck != null)
                    {
                        return new ReconsultationResponse { IsSuccessStatusCode = false, Message = "Already added for reconsultation", StatusCode = System.Net.HttpStatusCode.Conflict };
                        //response = Request.CreateResponse(HttpStatusCode.OK, new HttpResult { Message = "Already added for reconsultation", Response = false, Result = "Already added for reconsultation" });
                    }
                    else
                    {
                        return new ReconsultationResponse { IsSuccessStatusCode = false, Message = "Invalid Appointment Id", StatusCode = System.Net.HttpStatusCode.BadRequest };
                        //response = Request.CreateResponse(HttpStatusCode.OK, new HttpResult { Message = "Invalid Appointment Id", Response = false, Result = "Invalid Appointment Id" });
                    }
                }
            }
            else
            {
                return new ReconsultationResponse { IsSuccessStatusCode = false, Message = "Empty request data", StatusCode = System.Net.HttpStatusCode.BadRequest };
                //response = Request.CreateResponse(HttpStatusCode.BadRequest, new HttpResult { Message = "Empty request data", Response = true, Result = "Empty request data" });
            }
        }
    }
}
