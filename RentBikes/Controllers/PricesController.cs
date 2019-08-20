using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using RentBikes.Core.Repositories;
using RentBikes.Persistence;
using RentBikes.Persistence.Repositories;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RentBikes.Controllers
{
    public class PricesController : Controller
    {
        private Ibll_Base<Price> Biz => new bll_Base<Price>();

        // GET: Prices
        public ActionResult Index()
        {
            return View(Biz.GetAll());
        }

        // GET: Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Price price = Biz.Get(id ?? 0);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "priceID,rentalPrice,description,hours")] Price price)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(price);
                return RedirectToAction("Index");
            }

            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Price price = Biz.Get(id ?? 0);

            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "priceID,rentalPrice,description,hours")] Price price)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(price);
                return RedirectToAction("Index");
            }
            return View(price);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Price price = Biz.Get(id ?? 0);

            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
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