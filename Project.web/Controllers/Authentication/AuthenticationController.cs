using BAL.Helper;
using BAL.User;
using Project.Entity;
using Project.ResponseModel;
using Project.web.Models;
using Project.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Project.web.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        UserManager objUserManager = new UserManager();
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username , string password)
        {
            LoginRespnse Response = new LoginRespnse();
            Users users = new Users();
            try
            {
                users.Email = username;
                users.Password = password;

                Response = objUserManager.validateUser(users);

                if (Response.header.ErrorCode == 200)
                {                    
                        FormsAuthentication.SetAuthCookie(Response.response.Email, false);                       
                        SessionHelper session = new SessionHelper();
                        session.UserSession = new UserSession()
                        {
                            UserId = Response.response.UserId,
                            Username = Response.response.Email,
                            FullName = Response.response.FullName
                        };

                    return RedirectToRoute("home");               
                }
                else
                {
                    ViewBag.Error_Msg = Response.header.ErrorMessage;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error_Msg = ex.Message.ToString();
                BAL.Common.LogManager.LogError("Login Post Method", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
                return View();
            }
        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel userModel)
        {

            RegistrationResponse Response = new RegistrationResponse();
            Users users = new Users();
            try
            {
                users = objJavaScriptSerializer.Deserialize<Project.Entity.Users>(objJavaScriptSerializer.Serialize(userModel));

                Response = objUserManager.registerUser(users);

                if (Response.header.ErrorCode == 200)
                {
                    FormsAuthentication.SetAuthCookie(Response.response.Email, false);                  
                    SessionHelper session = new SessionHelper();
                    session.UserSession = new UserSession()
                    {
                        UserId = Response.response.UserId,
                        Username = Response.response.Email,
                        FullName = Response.response.FullName
                    };

                    return RedirectToRoute("home");
                }
                else
                {
                    ViewBag.Error_Msg = Response.header.ErrorMessage;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error_Msg = ex.Message.ToString();
                BAL.Common.LogManager.LogError("Registration Post Method", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
                return View();
            }
        }
        

        

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return Redirect("~/");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string Email)
        {
            ForgotPasswordResponse Response = new ForgotPasswordResponse();
            Users users = new Users();
            try
            {
                

                Response = objUserManager.resetPassword(Email);

                if (Response.header.ErrorCode == 200)
                {
                    string Body = Helper.PopulateBody(Helper.FirstLetterToUpper(Response.fullName), ConfigurationManager.AppSettings["ResetPasswordEmailTemplate"].ToString());

                    BAL.Helper.Helper.SendEmail(Email, "zeusMetrics", Body);
                    ViewBag.Success_Msg = "A mail on your registered mail is sent. Please check your Email.";
                    return RedirectToRoute("login");
                }
                else
                {
                    ViewBag.Error_Msg = Response.header.ErrorMessage;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error_Msg = ex.Message.ToString();
                BAL.Common.LogManager.LogError("ResetPassword Post Method", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdatePassword(string password , string authToken)
        {
            try
            {

            }
            catch(Exception ex)
            {
                ViewBag.Error_Msg = ex.Message.ToString();
                BAL.Common.LogManager.LogError("ResetPassword Post Method", 1, Convert.ToString(ex.Source), Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace));
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
    }
}