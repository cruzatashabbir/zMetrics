using Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ResponseModel
{
   public class LoginRespnse
    {
        public Header header { get; set; }

        public Users response { get; set; }

        public LoginRespnse()
        {
            header = new Header();
            response = new Users();
        }
    }

    //public class UserDetails
    //{
    //    public string UserId { get; set; }

    //    public string FullName { get; set; }

    //    public string CompanyName { get; set; }

    //    public string Email { get; set; }

    //    public string Password { get; set; }

    //    public string CreatedAt { get; set; }

    //    public string Status { get; set; }

    //    public string AuthToken { get; set; }
    //}
}
