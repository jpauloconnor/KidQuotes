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

        private readonly Lazy<IQuote> _quoteService;
        private IQuote QuoteService => _quoteService.Value;

        public QuoteController()
        {
            _quoteService = new Lazy<IQuote>(() => new QuoteService(Guid.Parse(User.Identity.GetUserId())));
        }

        //For Testing
        public QuoteController(Lazy<IQuote> quoteService)
        {
            _quoteService = quoteService;
        }

        // GET: Quote
        public ActionResult Index()
        {
            var model = _quoteService.Value.GetQuotes();

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


            if (QuoteService.CreateQuote(model))
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
            var detail = QuoteService.GetQuoteById(id);
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

            if (QuoteService.UpdateQuote(model))
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
            var model = QuoteService.GetQuoteById(id);

            return View(model);
        }



        // GET: Quote/Delete/5
        public ActionResult Delete(int id)
        {
            var model = QuoteService.GetQuoteById(id);

            return View(model);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuoteService.DeleteQuote(id);

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
    }
}