using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCSAMPLE.Models;
using System.Data;
using System.Reflection;
using UserSignupLogin.Models;

namespace MVCSAMPLE.Controllers
{
    public class LoginController : Controller
    {

        private readonly EmailService _emailService;

        public LoginController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult ContactInfo()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = "Contact Us Form Submission";
                string body = $"Name: {model.Name}<br>Email: {model.Email}<br>Message: {model.Message}";

                await _emailService.SendEmailAsync(model.Email, subject, body);

                ViewBag.Message = "Thank you for contacting us!";
                return View("ContactInfo", new ContactViewModel());
            }

            return View("ContactInfo", model);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registers()
        {
            return View();
        }
        public DataTable PutValue()
        {
            AppDBConnection Ac = new AppDBConnection();
            DataTable FetchValue = new DataTable();
            FetchValue=Ac.Dbcheck();
            return FetchValue;
           

        }
        public bool SetValue(UserModel usr)
        {
            AppDBConnection Ac = new AppDBConnection();
            DataTable FetchValue = new DataTable();
            bool val = Ac.DbEntry( usr);
            return val;


        }


        [HttpPost]

        public IActionResult verify(UserModel usr) {

            DataTable dt = new DataTable();
             dt = PutValue();
            if ((usr.username==null||usr.username == "") || (usr.Password == null || usr.Password == ""))
            {
                ViewBag.message = "EMPTY";
                return View("verify");
            }
            else
            {
                var ue = dt.AsEnumerable().Where(u => u["UsernameUS"].ToString().Equals(usr.username));
                var up = dt.AsEnumerable().Where(p => p["PasswordUS"].ToString().Equals(usr.Password));
                if (up.Count() > 0 && ue.Count()>0)
                {
                    ViewBag.message = "Update Coming Soon.....HOOOOOOOO.. HOOOOOO";
                    return View("LoginSuccess");
                }
                else
                {
                    ViewBag.message = "Please check your username and password and try again.";
                    return View("LoginFailed");
                }
            }

            }

        public IActionResult Register(UserModel usr)
        {
          
                bool status = SetValue(usr);
            if (status)
            {
                ViewBag.message = "True";
            }
            else
            {
                ViewBag.message = "False";

            }
          return View(usr);

        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View(new ContactViewModel());
        }

        
    }
    }

//    var users = new List<UserModel>
//{

//new UserModel { Id = 1,username="raj",Password="abc123" },
//new UserModel { Id = 2,username="ram",Password="cde123" },
//new UserModel { Id = 3,username="siva",Password="pol123" },
//new UserModel { Id = 4,username="kumar",Password="kcy123" },

//};
