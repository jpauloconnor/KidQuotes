using KidQuotes.Contracts;
using KidQuotes.WebMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Tests.Controllers
{
    [TestClass]
    public abstract class QuoteControllerTestsBase
    {

        protected QuoteController Controller;
        protected FakeQuoteService QuoteService;

        [TestInitialize]
        public virtual void Arrange()
        {
            QuoteService = new FakeQuoteService();

            Controller = new QuoteController(new Lazy<IQuote>(() => QuoteService));
        }


    }
}
