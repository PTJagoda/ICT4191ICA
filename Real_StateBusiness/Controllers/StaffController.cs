using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_StateBusiness.Models;


namespace Real_StateBusiness.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private MyContext mycontext = new MyContext();
        public ActionResult Index()
        {
            List<Staff> Staffs = mycontext.Staffs.ToList();
            return View(Staffs);

        }
        public ActionResult create()
        {
            ViewBag.BranchDetails = mycontext.Branches;
            return View();
        }
        [HttpPost]
        public ActionResult create(Staff staff)
        {
            ViewBag.BranchDetails = mycontext.Branches;
            mycontext.Staffs.Add(staff);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
           
            Staff staff = mycontext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(string id)
        {
            
            Staff staff = mycontext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(mycontext.Branches, "BranchNo", "BranchNo");
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(string id, Staff updatedStaff)
        {
            Staff staff = mycontext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.FName = updatedStaff.FName;
            staff.LName = updatedStaff.LName;
            staff.Position = updatedStaff.Position;
            staff.Salary = updatedStaff.Salary;
            staff.BranchRef = updatedStaff.BranchRef;
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {

            Staff staff = mycontext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteBranch(string id)
        {

            Staff staff = mycontext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            mycontext.Staffs.Remove(staff);
            mycontext.SaveChanges();
            return View(staff);
        }

    }
}