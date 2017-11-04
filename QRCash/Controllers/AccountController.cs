using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCash.Models;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace QRCash.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signup)
        {
            if (ModelState.IsValid)
            {
                var signUpModel = new { NickName = signup.Name, Email = signup.Email, Password = signup.Password };
                string localurl = Configuration.GetSection("ApiUrl").GetSection("SignUp").Value;
                var _response = await WebResponse.PostData(signUpModel, localurl);


                if (_response.IsSuccessStatusCode)
                {
                   return RedirectToAction("Index", "Home", new { });
                }
            }

            return View(signup);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn signin)
        {
            if (ModelState.IsValid)
            {
                var signUpModel = new { Email = signin.Email, Password = signin.Password };
                string localurl = Configuration.GetSection("ApiUrl").GetSection("SignIn").Value;
                var _response = await WebResponse.PostData(signUpModel, localurl);

                if (_response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home", new { });
                }
            }

            return View(signin);
        }
    }
}