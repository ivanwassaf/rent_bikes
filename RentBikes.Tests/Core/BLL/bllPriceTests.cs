using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;

namespace RentBikes.Tests.Core.BLL
{
    [TestClass]
    public class bllPriceTests
    {
        private readonly IBll_Price Biz = new bll_Price();

        private Price mock
        {
            get
            {
                Price price = new Price();
                price.rentalPrice = new Random(6).Next();
                price.description = "Price " + DateTime.Now.ToString();
                price.priceID = new Random(6).Next();
                return price;

            }
        }

        [TestMethod]
        public void Create()
        {
            try
            {
                Biz.Create(mock);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
