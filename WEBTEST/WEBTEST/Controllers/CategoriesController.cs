using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBTEST.Infra.EF;

namespace WEBTEST.Controllers
{
    public class CategoriesController : Controller
    {
        private WEBTECLATEntities db = new WEBTECLATEntities();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            return View(await db.TBCategories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategory tBCategory = await db.TBCategories.FindAsync(id);
            if (tBCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBCategory);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCategory,nameCategory")] TBCategory tBCategory)
        {
            if (ModelState.IsValid)
            {
                db.TBCategories.Add(tBCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBCategory);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategory tBCategory = await db.TBCategories.FindAsync(id);
            if (tBCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCategory,nameCategory")] TBCategory tBCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBCategory);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCategory tBCategory = await db.TBCategories.FindAsync(id);
            if (tBCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBCategory tBCategory = await db.TBCategories.FindAsync(id);
            db.TBCategories.Remove(tBCategory);
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
