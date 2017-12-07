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
using KidQuotes.Contracts;

namespace KidQuotes.WebMVC.Controllers
{
    [Authorize]
    public class QuoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IQuote _quote;

        public QuoteController(IQuote quote)
        {
            this._quote = quote;
        }

        public QuoteController()
        {
            this._quote = new QuoteService();
        }
        // GET: Quote
        public ViewResult Index()
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
        public ActionResult Edit(int id)
        {
            var service = CreateQuoteService();
            var detail = service.GetQuoteById(id);
            var model =
                new QuoteEditModel
                {
                    QuoteId = detail.QuoteId,
                    Quote = detail.Quote,
                    Description = detail.Description,
                    KidName = detail.KidName,
                    
                };

            return View(model);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QuoteEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.QuoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateQuoteService();

            if (service.UpdateQuote(model))
            {
                TempData["SaveResult"] = "Your note was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


        // GET: Quote/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateQuoteService();
            var model = svc.GetQuoteById(id);

            return View(model);
        }



        // GET: Quote/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = CreateQuoteService();
            var model = svc.GetQuoteById(id);

            return View(model);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateQuoteService();

            service.DeleteQuote(id);

            TempData["SaveResult"] = "Your note was deleted!";

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
