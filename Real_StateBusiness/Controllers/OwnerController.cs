using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_StateBusiness.Models;

namespace Real_StateBusiness.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        private MyContext mycontext = new MyContext();
        public ActionResult Index()
        {
            List<Owner> Owners = mycontext.Owners.ToList();
            return View(Owners);

        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Owner Owner)
        {
            mycontext.Owners.Add(Owner);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            Owner Owner = mycontext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(Owner);
        }

        public ActionResult Edit(string id)
        {

            Owner owner = mycontext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            ViewBag.OwnerDetails = new SelectList(mycontext.Owners, "FName", "Address","TelNo");
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(string id, Owner updatedOwner)
        {
            Owner owner = mycontext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.FName = updatedOwner.FName;
            owner.LName= updatedOwner.LName;
            owner.Address = updatedOwner.Address;
            owner.TellNo = updatedOwner.TellNo;
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult Delete(string id)
        {

            Owner owner = mycontext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteOwner(string id)
        {

            Owner owner = mycontext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            mycontext.Owners.Remove(owner);
            mycontext.SaveChanges();
            return View(owner);
        }
    }
}