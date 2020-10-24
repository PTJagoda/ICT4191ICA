using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_StateBusiness.Models;

namespace Real_StateBusiness.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private MyContext mycontext = new MyContext();
        public ActionResult Index()
        {
            List<Branch> AllBranches = mycontext.Branches.ToList();
            return View();
        }

        public ActionResult Staff()
        {
            List<Staff> AllStaffs = mycontext.Staffs.ToList();
            return View();
        }

        public ActionResult Rent()
        {
            List<Rent> AllRents = mycontext.Rents.ToList();
            return View();
        }

        public ActionResult Owner()
        {
            List<Owner> AllOwners = mycontext.Owners.ToList();
            return View();
        }

    }
}