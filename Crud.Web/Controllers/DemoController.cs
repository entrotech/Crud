using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class UserPref
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime? Expires { get; set; }
    }

    public class DemoController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var hdrs = Request.Headers;
            List<UserPref> model = new List<UserPref>();
            HttpCookie c = null;
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                c = Request.Cookies[i];
                model.Add(new UserPref {
                    Name = c.Name,
                    Value = c.Value });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserPref model)
        {
            Response.Cookies[model.Name].Value = model.Value;
            Response.Cookies[model.Name].Expires = model.Expires 
                ?? DateTime.Now.AddDays(2);

            // Alternatively, we could...
            //HttpCookie c = new HttpCookie(model.Name);
            //c.Value = model.Value;
            //c.Expires = model.Expires ?? DateTime.Now.AddDays(2);
            //Response.Cookies.Add(c);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string cookieName)
        {
            Response.Cookies[cookieName].Expires 
                = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index");
        }

    }
}