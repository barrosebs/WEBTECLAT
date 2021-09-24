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
using System.Net.Http;

namespace WEBTEST.Controllers
{
    public class ProductsController : Controller
    {
        private WEBTECLATEntities db = new WEBTECLATEntities();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var tBProducts = db.TBProducts.Include(t => t.TBCategory);
            return View(await tBProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProduct tBProduct = await db.TBProducts.FindAsync(id);
            if (tBProduct == null)
            {
                return HttpNotFound();
            }
            return View(tBProduct);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.idCategoryProduct = new SelectList(db.TBCategories, "idCategory", "nameCategory");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idProduct,nameProduct,priceProduct,imageProduct,descriptopnProduct,amountProduct,createdDateProduct,idCategoryProduct")] TBProduct tBProduct)
        {
            if (ModelState.IsValid)
            {
                db.TBProducts.Add(tBProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoryProduct = new SelectList(db.TBCategories, "idCategory", "nameCategory", tBProduct.idCategoryProduct);
            return View(tBProduct);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProduct tBProduct = await db.TBProducts.FindAsync(id);
            if (tBProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoryProduct = new SelectList(db.TBCategories, "idCategory", "nameCategory", tBProduct.idCategoryProduct);
            return View(tBProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idProduct,nameProduct,priceProduct,imageProduct,descriptopnProduct,amountProduct,createdDateProduct,idCategoryProduct")] TBProduct tBProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoryProduct = new SelectList(db.TBCategories, "idCategory", "nameCategory", tBProduct.idCategoryProduct);
            return View(tBProduct);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProduct tBProduct = await db.TBProducts.FindAsync(id);
            if (tBProduct == null)
            {
                return HttpNotFound();
            }
            return View(tBProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBProduct tBProduct = await db.TBProducts.FindAsync(id);
            db.TBProducts.Remove(tBProduct);
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
