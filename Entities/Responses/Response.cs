using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Responses
{
    public class Response
    {
        public Response()
        {
            Current_Balance = new Current_Balance();
            Bussines_Errors = new List<Business_Error>();
        }

        public Current_Balance Current_Balance { get; set; }
        public List<Business_Error> Bussines_Errors { get; set; }
        

    }
}
