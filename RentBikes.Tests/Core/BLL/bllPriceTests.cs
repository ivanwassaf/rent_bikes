using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using System;
using System.Linq;

namespace RentBikes.Tests.Core.BLL
{
    [TestClass]
    public class BllPriceTests
    {
        private readonly IBll_Price Biz = new Bll_Price();

        private Price Getmock()
        {
            Price price = new Price
            {
                rentalPrice = new Random().Next(),
                description = "TEST " + DateTime.Now.ToString(),
                hours = new Random().Next()
            };
            return price;
        }

        //private void Setmock(Price value)
        //{ }

        [TestMethod]
        public void Create()
        {
            try
            {
                Biz.Create(Getmock());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
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
                Assert.Fail(ex.Message);
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
                Assert.Fail(ex.Message);
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
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void EditTest()
        {
            try
            {
                Price mock1 = Biz.GetAll().FirstOrDefault();
                mock1.description = "TEST " + DateTime.Now.ToString();
                Biz.Edit(mock1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
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
                Assert.Fail(ex.Message);
            }
        }
    }
}
