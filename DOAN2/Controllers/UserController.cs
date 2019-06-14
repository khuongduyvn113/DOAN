using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}