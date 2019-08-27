using System.Net;
using System.Web.Mvc;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;

namespace RentBikes.Controllers
{
    public class VehicleTypesController : Controller
    {
        private IBll_VehicleType Biz
        {
            get { return new Bll_VehicleType(); }
        }

        // GET: VehicleTypes
        public ActionResult Index()
        {
            //var vehicleTypes = db.VehicleTypes.Include(v => v.State);
            return View(Biz.GetAll());
        }

        // GET: VehicleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = Biz.Get(id ?? 0);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public ActionResult Create()
        {
            ViewBag.stateID = Helper.States(null);
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleTypeID,description,stateID")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(vehicleType);
                return RedirectToAction("Index");
            }

            ViewBag.stateID = Helper.States(vehicleType.stateID);
            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = Biz.Get(id ?? 0);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            ViewBag.stateID = Helper.States(vehicleType.stateID);
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleTypeID,description,stateID")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(vehicleType);
                return RedirectToAction("Index");
            }
            ViewBag.stateID = Helper.States(vehicleType.stateID);
            return View(vehicleType);
        }

        // GET: VehicleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = Biz.Get(id ?? 0);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
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
