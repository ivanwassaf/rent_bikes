using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using System.Net;
using System.Web.Mvc;

namespace RentBikes.Controllers
{
    public class StationsController : Controller
    {
        private IBll_Station Biz
        {
            get { return new Bll_Station(); }
        }

        // GET: Stations
        public ActionResult Index()
        {
            //var stations = db.Stations.Include(s => s.State);
            return View(Biz.GetAll());
        }

        // GET: Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = Biz.Get(id ?? 0);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Stations/Create
        public ActionResult Create()
        {
            //ViewBag.stateID = new SelectList(db.States, "stateID", "description");
            ViewBag.stateID = Helper.States(null);
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stationID,description,address,stateID")] Station station)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(station);
                return RedirectToAction("Index");
            }

            ViewBag.stateID = Helper.States(station.stateID);
            return View(station);
        }

        // GET: Stations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = Biz.Get(id ?? 0);
            if (station == null)
            {
                return HttpNotFound();
            }
            ViewBag.stateID = Helper.States(station.stateID);
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stationID,description,address,stateID")] Station station)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(station);
                return RedirectToAction("Index");
            }
            ViewBag.stateID = Helper.States(station.stateID);
            return View(station);
        }

        // GET: Stations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = Biz.Get(id ?? 0);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Stations/Delete/5
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
