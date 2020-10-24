using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_StateBusiness.Models;

namespace Real_StateBusiness.Controllers
{
    public class RentController : Controller
    {
        private MyContext mycontext = new MyContext();
        // GET: Rent
        public ActionResult Index()
        {
            List<Rent> rents = mycontext.Rents.ToList();
            return View(rents);
        }
        public ActionResult create()
        {
            ViewBag.BranchDetails = mycontext.Branches;
            ViewBag.StaffDetails = mycontext.Staffs;
            ViewBag.OwnerDetails = mycontext.Owners;
            return View();
        }
        [HttpPost]
        public ActionResult create(Rent rent)
        {
            ViewBag.BranchDetails = mycontext.Branches;
            ViewBag.StaffDetails = mycontext.Staffs;
            ViewBag.OwnerDetails = mycontext.Owners;
            mycontext.Rents.Add(rent);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {

            Rent rent = mycontext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

         public ActionResult Edit(string id)
         {

            Rent rent = mycontext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.BranchDetails = new SelectList(mycontext.Branches, "BranchNo", "BranchNo");
            ViewBag.OwnerDetails = new SelectList(mycontext.Owners, "OwnerNo", "OwnerNo");
            ViewBag.StaffDetails = new SelectList(mycontext.Staffs, "StaffNo", "StaffNo");
            return View(rent);
        }
         [HttpPost]
         public ActionResult Edit(string id, Rent updatedRent)
         {
            Rent rent = mycontext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.Street = updatedRent.Street;
            rent.City = updatedRent.City;
            rent.Ptype = updatedRent.Ptype;
            rent.Rooms = updatedRent.Rooms;
            rent.OwnerRef = updatedRent.OwnerRef;
            rent.StaffRef = updatedRent.StaffRef;
            rent.BranchRef = updatedRent.BranchRef;
            mycontext.SaveChanges();
             return RedirectToAction("Index");
         }

         public ActionResult Delete(string id)
         {

            Rent rent = mycontext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
         }

         [HttpPost, ActionName("Delete")]

         public ActionResult DeleteRent(string id)
         {

            Rent rent = mycontext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            mycontext.Rents.Remove(rent);
             mycontext.SaveChanges();
             return View(rent);
         }

        public ActionResult City()
        {
            var Allcity = mycontext.Rents.ToList();

            int x = 0;
            int y = 0;

            foreach(Rent rent in Allcity)
            {
                x = x + 1;
            }

            string[] pos = new string[x];

            foreach(Rent rent in Allcity)
            {
                pos[y] = rent.City;
                y = y + 1;
            }

            var distinctArray = pos.Distinct().ToArray();
            ViewBag.City = distinctArray;

            return View();
        }

        public ActionResult city1(string cy)
        {
            List<Rent> rent = mycontext.Rents.Where(x => x.City == cy).ToList();
            return View(rent);
        }


    }
}