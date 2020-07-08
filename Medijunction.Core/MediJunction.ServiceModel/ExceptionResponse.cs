using System;
using System.Collections.Generic;
using System.Text;

namespace MediJunction.ServiceModel
{
    public class ExceptionResponse : Exception
    {
        public string ExceptionMessage { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
