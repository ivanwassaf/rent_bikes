﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;

namespace RentBikes.Tests.Core.BLL
{
    [TestClass]
    public class BllPriceTests
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
                Client mock1 = Biz.GetAll().FirstOrDefault();
                Biz.Delete(mock1.clientID);
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
                Client mock1 = Biz.GetAll().FirstOrDefault();
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
