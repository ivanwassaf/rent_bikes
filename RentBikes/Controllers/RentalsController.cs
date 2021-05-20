using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using System.Net;
using System.Web.Mvc;

namespace RentBikes.Controllers
{
    public class RentalsController : Controller
    {
        //private Context db = new Context();

        private IBll_Rental Biz
        {
            get { return new Bll_Rental(); }
        }

        // GET: Rentals
        public ActionResult Index()
        {
            //var rentals = db.Rentals.Include(r => r.Client).Include(r => r.RentalType).Include(r => r.State).Include(r => r.Station);
            return View(Biz.GetAll());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = Biz.Get(id ?? 0);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.clientID = Helper.Clients(null);
            ViewBag.rentalTypeID = Helper.RentalTypes(null);
            ViewBag.stateID = Helper.States(null);
            ViewBag.stationID = Helper.Stations(null);
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rentalID,from,to,stateID,stationID,rentalTypeID,subtotal,total,clientID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(rental);
                return RedirectToAction("Index");
            }

            ViewBag.clientID = Helper.Clients(rental.clientID);
            ViewBag.rentalTypeID = Helper.RentalTypes(rental.rentalTypeID);
            ViewBag.stateID = Helper.States(rental.stateID);
            ViewBag.stationID = Helper.Stations(rental.stationID);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = Biz.Get(id ?? 0);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = Helper.Clients(rental.clientID);
            ViewBag.rentalTypeID = Helper.RentalTypes(rental.rentalTypeID);
            ViewBag.stateID = Helper.States(rental.stateID);
            ViewBag.stationID = Helper.Stations(rental.stationID);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rentalID,from,to,stateID,stationID,rentalTypeID,subtotal,total,clientID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(rental);
                return RedirectToAction("Index");
            }
            ViewBag.clientID = Helper.Clients(rental.clientID);
            ViewBag.rentalTypeID = Helper.RentalTypes(rental.rentalTypeID);
            ViewBag.stateID = Helper.States(rental.stateID);
            ViewBag.stationID = Helper.Stations(rental.stationID);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = Biz.Get(id ?? 0);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
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
