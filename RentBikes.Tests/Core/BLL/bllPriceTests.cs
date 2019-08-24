using System;
using System.Linq;
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
                price.rentalPrice = new Random().Next();
                price.description = "TEST " + DateTime.Now.ToString();
                price.hours = new Random().Next();
                return price;
            }
            set { }
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

        [TestMethod()]
        public void GetAllTest()
        {
            try
            {
                Biz.GetAll();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetTest()
        {
            try
            {
                Biz.Get(1);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            try
            {
                Price mock1 = Biz.GetAll().FirstOrDefault();
                Biz.Delete(mock1.priceID);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void EditTest()
        {
            try
            {
                Price mock1 = Biz.GetAll().FirstOrDefault();
                mock1.description = "TEST " + DateTime.Now.ToString();
                Biz.Edit(mock);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void DetailsTest()
        {
            try
            {
                Biz.Details(x => x.priceID > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
