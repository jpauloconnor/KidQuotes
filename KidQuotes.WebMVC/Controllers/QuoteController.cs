using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KidQuotes.Data;

namespace KidQuotes.WebMVC.Controllers
{
    public class QuoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quote
        public ActionResult Index()
        {
            return View(db.Quotes.ToList());
        }

        // GET: Quote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteEntity quoteEntity = db.Quotes.Find(id);
            if (quoteEntity == null)
            {
                return HttpNotFound();
            }
            return View(quoteEntity);
        }

        // GET: Quote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteId,OwnerId,Quote,Description,KidName,CreatedUtc,ModifiedUtc")] QuoteEntity quoteEntity)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quoteEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quoteEntity);
        }

        // GET: Quote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteEntity quoteEntity = db.Quotes.Find(id);
            if (quoteEntity == null)
            {
                return HttpNotFound();
            }
            return View(quoteEntity);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteId,OwnerId,Quote,Description,KidName,CreatedUtc,ModifiedUtc")] QuoteEntity quoteEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quoteEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quoteEntity);
        }

        // GET: Quote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteEntity quoteEntity = db.Quotes.Find(id);
            if (quoteEntity == null)
            {
                return HttpNotFound();
            }
            return View(quoteEntity);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuoteEntity quoteEntity = db.Quotes.Find(id);
            db.Quotes.Remove(quoteEntity);
            db.SaveChanges();
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
