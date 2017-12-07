using KidQuotes.Contracts;
using KidQuotes.Data;
using KidQuotes.Models;
using KidQuotes.WebMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace QuoteService.Tests
{
    [TestClass()]
    public class QuoteControllerTests
    {

        [TestMethod()]
        public void Index_Returns_All_Quotes_In_DB()
        {
            //Arrange
            var quote = Mock.Create<IQuote>();
            
            Mock.Arrange(() => quote.GetQuotes()).
                Returns(new List<QuoteListModel>()
                {
                    new QuoteListModel { Quote = "Hey", KidName="Sophie", QuoteId=1, CreatedUtc=DateTimeOffset.Parse("2005-09-01")},
                    new QuoteListModel { Quote = "Hey", KidName="Sophie", QuoteId=2, CreatedUtc=DateTimeOffset.Parse("2005-09-01")}

            }).MustBeCalled();
            Guid newGuid = new Guid();
           

            //Act
            QuoteController controller = new QuoteController(quote);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<QuoteListModel>;

            //Assert
            Assert.AreEqual(quote, 2);
        }

        [TestMethod()]
        public void QuoteCreateTest()
        {
            //Arrange
            QuoteController quoteController = new QuoteController();
            
            //Act
            ActionResult result = quoteController.Create() as ActionResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod()]
        public void QuoteIndexTest()
        {
            //Arrange
            QuoteController quoteController = new QuoteController();

            //Act
            ActionResult result = quoteController.Create() as ActionResult;

            //Assert
            Assert.IsNotNull(result);

        }
    }
}