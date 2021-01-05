using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductMgmtMvc.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.SessionState;
namespace ProductMgmtMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(admin admin)
        {
            var form = new Dictionary<string, string>
            {
                {"username" ,admin.username },
                {"password" ,admin.password },
                {"grant_type","password" },

            };
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60760/");
            var postTask = client.PostAsync("token",new FormUrlEncodedContent(form));
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var responseData = result.Content.ReadAsAsync<TokenModel>().Result;
                // var jsondata = JsonConvert.DeserializeObject<>(responseData);
                Session["token"] = responseData.access_token;
                Session["User"] =admin.username;
                return RedirectToAction("Index", "Main");
                    }
            else
            {
                TempData["Message"] = "Wrong Credential";
                return RedirectToAction("Index");
            }

        }
       
    }
}