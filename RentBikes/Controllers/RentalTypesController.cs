using RentBikes.Core.BLL;
using RentBikes.Core.Domain;
using System.Net;
using System.Web.Mvc;

namespace RentBikes.Controllers
{
    public class RentalTypesController : Controller
    {
        private IBll_RentalType Biz
        {
            get { return new Bll_RentalType(); }
        }

        // GET: RentalTypes
        public ActionResult Index()
        {
            return View(Biz.GetAll());
        }

        // GET: RentalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalType rentalType = Biz.Get(id ?? 0);
            if (rentalType == null)
            {
                return HttpNotFound();
            }
            return View(rentalType);
        }

        // GET: RentalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rentalTypeID,description,discount")] RentalType rentalType)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(rentalType);
                return RedirectToAction("Index");
            }

            return View(rentalType);
        }

        // GET: RentalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalType rentalType = Biz.Get(id ?? 0);
            if (rentalType == null)
            {
                return HttpNotFound();
            }
            return View(rentalType);
        }

        // POST: RentalTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rentalTypeID,description,discount")] RentalType rentalType)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(rentalType);
                return RedirectToAction("Index");
            }
            return View(rentalType);
        }

        // GET: RentalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalType rentalType = Biz.Get(id ?? 0);
            if (rentalType == null)
            {
                return HttpNotFound();
            }
            return View(rentalType);
        }

        // POST: RentalTypes/Delete/5
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
