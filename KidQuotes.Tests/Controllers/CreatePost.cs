using KidQuotes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KidQuotes.Tests.Controllers
{

    [TestClass]
    public class CreatePost : QuoteControllerTestsBase
    {
        private QuoteCreateModel _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            QuoteService.CreateQuoteReturnValue = true;
        }

        private ActionResult Act()
        {
            
            return Controller.Create(_model);
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Your quote was created.", Controller.TempData["SaveResult"]);
        }

    }
}
