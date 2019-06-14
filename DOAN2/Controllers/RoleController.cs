using Microsoft.AspNet.Identity.EntityFramework;
using DOAN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN2.Controllers
{
    [Authorize(Roles = "Manager")]
    public class RoleController : Controller
    {
        // GET: Role
        ApplicationDbContext dbContext;

        public RoleController()
        {
            dbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = dbContext.Roles.ToList();
            return View(Roles);

        }
        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {


            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            dbContext.Roles.Add(Role);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
