using KidQutoes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidQuotes.Models;

namespace KidQuotes.Services
{
    public class QuoteService : IQuote
    {
        public bool CreateQuote(QuoteCreateModel model)
        {
            throw new NotImplementedException();
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
