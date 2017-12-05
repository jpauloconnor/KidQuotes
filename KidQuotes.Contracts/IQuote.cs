using KidQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Contracts
{
    public interface IQuote
    {
        bool CreateQuote(QuoteCreateModel model);
        IEnumerable<QuoteListModel> GetQuotes();
        QuoteDetailsModel GetQuoteById(int quoteId);
        bool UpdateQuote(QuoteEditModel model);
        bool DeleteQuote(int quoteId);
    }
}
