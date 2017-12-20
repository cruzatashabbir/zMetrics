using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ResponseModel
{
   public class ForgotPasswordResponse
    {
        public Header header { get; set; }

        public string fullName { get; set; }
        public ForgotPasswordResponse()
        {
            header = new Header();
        }
    }
}
