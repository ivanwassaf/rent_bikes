using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using System;
using System.Linq;

namespace RentBikes.Tests.Core.BLL
{
    [TestClass]
    public class BllClientTests
    {
        private readonly IBll_Client Biz = new Bll_Client();

        private Client Getmock()
        {
            Client client = new Client
            {
                identification = new Random().Next().ToString(),
                name = "TEST " + DateTime.Now.ToString(),
                address = new Random().Next().ToString(),
                stateID = 1
            };
            return client;
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
                //Debi agregar el metodo GetAllFull para que traiga las relaciones
                //y poder verificar si no habian FK contra Rental sino pinchaba
                Client mock1 = Biz.GetAllFull().FirstOrDefault(x => x.Rental.Count == 0);
                Biz.Delete(mock1.clientID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + " - " + ex.InnerException?.Message);
            }
        }

        [TestMethod()]
        public void EditTest()
        {
            try
            {
                Client mock1 = Biz.GetAll().OrderByDescending(x => x.clientID).FirstOrDefault();
                mock1.name = "TEST " + DateTime.Now.ToString();
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
                Biz.Details(x => x.clientID > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
