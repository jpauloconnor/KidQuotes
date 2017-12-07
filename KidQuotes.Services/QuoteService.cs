using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidQuotes.Models;
using KidQuotes.Data;
using KidQuotes.Contracts;

namespace KidQuotes.Services
{
    public class QuoteService : IQuote
    {
        private readonly Guid _userId;

        public QuoteService(Guid userId)
        {
            _userId = userId;
        }
        public QuoteService()
        {

        }

        public bool CreateQuote(QuoteCreateModel model)
        {
            var entity =
                new QuoteEntity
                {
                    OwnerId = _userId,
                    Quote = model.Quote,
                    Description = model.Description,
                    KidName = model.KidName,
                    CreatedUtc = DateTimeOffset.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Quotes.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuoteListModel> GetQuotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Quotes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new QuoteListModel
                                {
                                    QuoteId = e.QuoteId,
                                    Quote = e.Quote,
                                    KidName = e.KidName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public QuoteDetailsModel GetQuoteById(int quoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Quotes
                        .Single(e => e.QuoteId == quoteId && e.OwnerId == _userId);

                return
                    new QuoteDetailsModel
                    {
                        QuoteId = entity.QuoteId,
                        Quote = entity.Quote,
                        Description = entity.Description,
                        KidName = entity.KidName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateQuote(QuoteEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Quotes
                        .Single(e => e.QuoteId == model.QuoteId && e.OwnerId == _userId);

                entity.Quote = model.Quote;
                entity.Description = model.Description;
                entity.KidName = model.KidName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteQuote(int quoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Quotes
                        .Single(e => e.QuoteId == quoteId && e.OwnerId == _userId);

                ctx.Quotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
