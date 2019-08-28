using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;

namespace RentBikes.Tests.Core.BLL
{
    [TestClass]
    public class BllStationTests
    {
        private readonly IBll_Station Biz = new Bll_Station();

        private Station Getmock()
        {
            Station station = new Station
            {
                stationID = new Random().Next(),
                description = "TEST " + DateTime.Now.ToString(),
                address = new Random().Next().ToString(),
                stateID = 1
            };
            return station;
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
                Station mock1 = Biz.GetAll().FirstOrDefault();
                Biz.Delete(mock1.stationID);
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
                Station mock1 = Biz.GetAll().FirstOrDefault();
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
                Biz.Details(x => x.stationID > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
