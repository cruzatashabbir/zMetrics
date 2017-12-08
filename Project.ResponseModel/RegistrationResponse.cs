using Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ResponseModel
{
  public class RegistrationResponse
    {
        public Header header { get; set; }

        public Users response { get; set; }

        public RegistrationResponse()
        {
            header = new Header();
            response = new Users();
        }
    }
}
