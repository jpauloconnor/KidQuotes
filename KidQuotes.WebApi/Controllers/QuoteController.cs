using KidQuotes.Models;
using KidQuotes.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KidQuotes.WebApi.Controllers
{
    [Authorize]
    public class QuoteController : ApiController
    {
        // GET /api/note
        public IHttpActionResult GetAll()
        {
            var quoteService = CreateQuoteService();
            var quotes = quoteService.GetQuotes();
            return Ok(quotes);
        }
        public IHttpActionResult Get(int id)
        {
            var quoteService = CreateQuoteService();
            var quote = quoteService.GetQuoteById(id);
            return Ok(quote);
        }

        public IHttpActionResult Post(QuoteCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateQuoteService();

            if (!service.CreateQuote(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(QuoteEditModel quote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateQuoteService();

            if (!service.UpdateQuote(quote))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateQuoteService();

            if (!service.DeleteQuote(id))
                return InternalServerError();

            return Ok();
        }

        private QuoteService CreateQuoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var quoteService = new QuoteService(userId);
            return quoteService;
        }
    }
}
