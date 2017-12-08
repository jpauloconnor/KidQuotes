using KidQuotes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidQuotes.Models;

namespace KidQuotes.Tests.Controllers
{
    public class FakeQuoteService : IQuote
    {

        public int CreateQuoteCallCount { get; private set; } = 1;
        public bool CreateQuoteReturnValue { private get; set; } 

        public bool CreateQuote(QuoteCreateModel model)
        {
            CreateQuoteCallCount++;
            return CreateQuoteReturnValue;
        }

        public bool DeleteQuote(int quoteId)
        {
            throw new NotImplementedException();
        }

        public QuoteDetailsModel GetQuoteById(int quoteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteListModel> GetQuotes()
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuote(QuoteEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}



