using System;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using RentBikes.Core.BLL;
using RentBikes.Core.Domain;

namespace RentBikes.Controllers
{
    public class ClientsController : Controller
    {
        private IBll_Client Biz
        {
            get { return new Bll_Client(); }
        }

        // GET: Clients
        public ActionResult Index()
        {
            //var clients = db.Clients.Include(s => s.State);
            return View(Biz.GetAll());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client entity = Biz.Get(id ?? 0);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            //ViewBag.stateID = new SelectList(db.States, "stateID", "description");
            //ViewBag.stateID = States(null);
            ViewBag.stateID = Helper.States(null);
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,name,identification,address,stateID")] Client client)
        {
            if (ModelState.IsValid)
            {
                Biz.Create(client);
                return RedirectToAction("Index");
            }

            ViewBag.stateID = Helper.States(client.stateID);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = Biz.Get(id ?? 0);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.stateID = Helper.States(client.stateID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,name,identification,address,stateID")] Client client)
        {
            if (ModelState.IsValid)
            {
                Biz.Edit(client);
                return RedirectToAction("Index");
            }
            ViewBag.stateID = Helper.States(client.stateID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = Biz.Get(id ?? 0);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Biz.Delete(id);
            }
            catch (Exception ex)
            {
                Delete(id);
                ViewBag.Message = ex.Message + " " + ex.InnerException?.InnerException?.Message;
                return View();
            }
            
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
