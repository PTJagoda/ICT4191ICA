using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_StateBusiness.Models;

namespace Real_StateBusiness.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        private MyContext mycontext = new MyContext();
        public ActionResult Index()
        {
            List<Branch> Branches = mycontext.Branches.ToList();
            return View(Branches);
            
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Branch branch)
        {
            mycontext.Branches.Add(branch);
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            Branch branch = mycontext.Branches.SingleOrDefault(x => x.BranchNo==id);
            return View(branch);
        }

        public ActionResult Edit(string id)
        {
           
            Branch branch = mycontext.Branches.SingleOrDefault(x => x.BranchNo == id);
            ViewBag.BranchDetails = new SelectList(mycontext.Branches,"Street","City","PostCode");
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(string id, Branch updatedBranch)
        {
            Branch branch = mycontext.Branches.SingleOrDefault(x => x.BranchNo == id);
            branch.City = updatedBranch.City;
            branch.Street = updatedBranch.Street;
            branch.PostCode = updatedBranch.PostCode;
            mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {

            Branch branch = mycontext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteBranch(string id)
        {

            Branch branch = mycontext.Branches.SingleOrDefault(x => x.BranchNo == id);
            mycontext.Branches.Remove(branch);
            mycontext.SaveChanges();
            return View(branch);
        }

        public ActionResult Branch(string br)
        {
            
            var Allbranch = mycontext.Branches.ToList();

            int x = 0;
            int y = 0;

            foreach(Branch branch in Allbranch)
            {
                x = x + 1;
            }

            string[] pos = new string[x];

            foreach (Branch branch in Allbranch)
            {
                pos[y] = branch.BranchNo;
                y = y + 1;
            }

            var distinctArray = pos.Distinct().ToArray();
            ViewBag.BranchNo = distinctArray;


            return View();
        }

        public ActionResult NoOfBilding(string br)
        { 
            ViewBag.count = mycontext.Rents.Where(x => x.BranchRef == br).ToList().Count();
            return View();

        }


    }
}