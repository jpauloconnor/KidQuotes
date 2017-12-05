using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KidQuotes.Data;
using KidQuotes.Services;
using Microsoft.AspNet.Identity;
using KidQuotes.Models;

namespace KidQuotes.WebMVC.Controllers
{
    [Authorize]
    public class QuoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quote
        public ActionResult Index()
        {
            var service = CreateQuoteService();
            var model = service.GetQuotes();

            return View(model);
        }

        // GET: Quote/Create
        public ActionResult Create()
        {
            return View();
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

        

        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuoteCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateQuoteService();

            if (service.CreateQuote(model))
            {
                TempData["SaveResult"] = "Your quote was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be created.");
            return View(model);
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

        private QuoteService CreateQuoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuoteService(userId);
            return service;
        }
    }
}
