using KidQutoes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidQuotes.Models;
using KidQuotes.Data;

namespace KidQuotes.Services
{
    public class QuoteService : IQuote
    {
        private readonly Guid _userId;

        public QuoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuote(QuoteCreateModel model)
        {
            var entity =
                new QuoteEntity
                {
                    OwnerId = _userId,
                    Quote = model.Quote,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Quotes.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
       

        public bool DeleteQuote(int quoteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteListModel> GetNotes()
        {
            throw new NotImplementedException();
        }

        public QuoteDetailsModel GetQuoteById(int quoteId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuote(QuoteEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
