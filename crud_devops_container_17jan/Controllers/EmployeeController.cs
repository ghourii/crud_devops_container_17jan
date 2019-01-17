using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace crud_devops_container_17jan.Controllers
{
    public class EmployeeController : Controller
    {


        private learningsqlEntities db = new learningsqlEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
          
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(EMPLOYEE model)
        {


            if (ModelState.IsValid)
            {
                db.EMPLOYEEs.Add(model);
                 db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

          
            return View(model);
        }

        [HttpPost]
        public string LoadBranch()
        {
            var res = "<option value=''>--Select branch--</option>";
            var collection = db.BRANCHes.ToList();
            foreach (var item in collection)
            {
                res += "<option value='" + item.BRANCH_ID + "'>" + item.NAME + "</option>";
            }
            return res;
        }

        [HttpPost]

        public string LoadDept()
        {

            var res = "<option value=''>--Select Dept--</option>";
            var collection = db.DEPARTMENTs.ToList();
            foreach (var item in collection)
            {
                res += "<option value='" + item.DEPT_ID + "'>" + item.NAME + "</option>";
            }
            return res;

        }


    }
}