using DAL;
using Project.Entity;
using Project.ResponseModel;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BAL.User
{
    public class UserManager
    {
        public LoginRespnse validateUser(Users users)
        {
            objResponse Response = new objResponse();
            LoginRespnse results = new LoginRespnse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://zmetricsapi.cruzata.com/auth/login");

                    //HTTP POST                   
                    var postTask = client.PostAsJsonAsync<Users>("login", users);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<LoginRespnse>();
                        readTask.Wait();

                        results = readTask.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                results.header.ErrorMessage = ex.Message.ToString();
                BAL.Common.LogManager.LogError("validate User", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
            }

            return results;
        }

        public RegistrationResponse registerUser(Users users)
        {
            objResponse Response = new objResponse();
            RegistrationResponse results = new RegistrationResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://zmetricsapi.cruzata.com/auth/register");

                    //HTTP POST                   
                    var postTask = client.PostAsJsonAsync<Users>("register", users);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<RegistrationResponse>();
                        readTask.Wait();

                        results = readTask.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                results.header.ErrorMessage = ex.Message.ToString();
                BAL.Common.LogManager.LogError("Register User", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
            }

            return results;
        }

       


        

       
    }
}
