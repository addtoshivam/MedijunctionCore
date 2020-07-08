using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MediJunction.ServiceModel.Response
{
    public class ReconsultationResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
