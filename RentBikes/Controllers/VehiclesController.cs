using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using RentBikes.Persistence;

namespace RentBikes.Controllers
{
    public class VehiclesController : Controller
    {
        private IBll_Vehicle Biz
        {
            get { return new Bll_Vehicle(); }
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            //var vehicles = db.Vehicles.Include(v => v.State).Include(v => v.VehicleType);
            return View(Biz.GetAll());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Biz.Get(id ?? 0);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.stateID = Helper.States(null);
            ViewBag.vehicleTypeID = Helper.VehicleTypes(null);
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleID,description,vehicleTypeID,stateID,serie")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(vehicle);
                return RedirectToAction("Index");
            }

            ViewBag.stateID = Helper.States(vehicle.stateID);
            ViewBag.vehicleTypeID = Helper.VehicleTypes(vehicle.vehicleTypeID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Biz.Get(id ?? 0);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.stateID = Helper.States(vehicle.stateID);
            ViewBag.vehicleTypeID = Helper.VehicleTypes(vehicle.vehicleTypeID);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleID,description,vehicleTypeID,stateID,serie")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.stateID = Helper.States(vehicle.stateID);
            ViewBag.vehicleTypeID = Helper.VehicleTypes(vehicle.vehicleTypeID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = Biz.Get(id ?? 0);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biz.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
