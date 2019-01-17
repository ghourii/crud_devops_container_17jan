using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace crud_devops_container_17jan.Controllers
{
    public class CUSTOMERsController : Controller
    {
        private learningsqlEntities db = new learningsqlEntities();

        // GET: CUSTOMERs
        public async Task<ActionResult> Index()
        {
            var cUSTOMERs = db.CUSTOMERs.Include(c => c.BUSINESS).Include(c => c.INDIVIDUAL);
            return View(await cUSTOMERs.ToListAsync());
        }

        // GET: CUSTOMERs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Create
        public ActionResult Create()
        {
            ViewBag.CUST_ID = new SelectList(db.BUSINESSes, "CUST_ID", "NAME");
            ViewBag.CUST_ID = new SelectList(db.INDIVIDUALs, "CUST_ID", "FIRST_NAME");
            return View();
        }

        // POST: CUSTOMERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CUST_ID,ADDRESS,CITY,CUST_TYPE_CD,FED_ID,POSTAL_CODE,STATE")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERs.Add(cUSTOMER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CUST_ID = new SelectList(db.BUSINESSes, "CUST_ID", "NAME", cUSTOMER.CUST_ID);
            ViewBag.CUST_ID = new SelectList(db.INDIVIDUALs, "CUST_ID", "FIRST_NAME", cUSTOMER.CUST_ID);
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUST_ID = new SelectList(db.BUSINESSes, "CUST_ID", "NAME", cUSTOMER.CUST_ID);
            ViewBag.CUST_ID = new SelectList(db.INDIVIDUALs, "CUST_ID", "FIRST_NAME", cUSTOMER.CUST_ID);
            return View(cUSTOMER);
        }

        // POST: CUSTOMERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CUST_ID,ADDRESS,CITY,CUST_TYPE_CD,FED_ID,POSTAL_CODE,STATE")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CUST_ID = new SelectList(db.BUSINESSes, "CUST_ID", "NAME", cUSTOMER.CUST_ID);
            ViewBag.CUST_ID = new SelectList(db.INDIVIDUALs, "CUST_ID", "FIRST_NAME", cUSTOMER.CUST_ID);
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: CUSTOMERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            db.CUSTOMERs.Remove(cUSTOMER);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
