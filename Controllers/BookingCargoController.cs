using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoManagement;
using CargoManagement.Models;

namespace CargoManagement.Controllers
{
    [Authorize]
    public class BookingCargoController : Controller
    {
        private CargoDB db = new CargoDB();
        public ActionResult Display()
        {
            return View();

        }
        
        // GET: bookingCargoes
       // [Authorize(Roles ="Customer")]
        public ActionResult Index()
        {
            var bookingCargo = db.bookingCargo.Include(b => b.customer).Include(b => b.product).Include(b=>b.city);
            return View(bookingCargo.ToList());
        }

        // GET: bookingCargoes/Details/5

        //[Authorize(Roles = "Customer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargo.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            return View(bookingCargo);
        }

        // GET: bookingCargoes/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.customer, "Customer_ID", "Customer_Name");
            ViewBag.Product_ID = new SelectList(db.product, "Product_ID", "Product_Name");
            ViewBag.City_ID = new SelectList(db.city, "City_ID", "City");
            return View();
        }

        // POST: bookingCargoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Customer_ID,Product_ID,Quantity,City_ID")] bookingCargo bookingCargo)
        {
            if (ModelState.IsValid)
            {
                db.bookingCargo.Add(bookingCargo);
                db.SaveChanges();
                
                
                return RedirectToAction("Display");
            }

            ViewBag.Customer_Name = new SelectList(db.customer, "Customer_ID", "Customer_Name", bookingCargo.Customer_ID);
            ViewBag.Product_Name = new SelectList(db.product, "Product_ID", "Product_Name", bookingCargo.Product_ID);
            ViewBag.City = new SelectList(db.city, "City_ID", "City", bookingCargo.City_ID);
            return View(bookingCargo);
        }

        // GET: bookingCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargo.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.customer, "Customer_ID", "Customer_Name", bookingCargo.Customer_ID);
            ViewBag.Product_ID = new SelectList(db.product, "Product_ID", "Product_Name", bookingCargo.Product_ID);
            ViewBag.City_ID = new SelectList(db.city, "City_ID", "City", bookingCargo.City_ID);
            return View(bookingCargo);
        }

        // POST: bookingCargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Customer_ID,Product_ID,Quantity, City_ID")] bookingCargo bookingCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.customer, "Customer_ID", "customer_name", bookingCargo.Customer_ID);
            ViewBag.Product_ID = new SelectList(db.product, "Product_ID", "product_name", bookingCargo.Product_ID);
            ViewBag.City_ID = new SelectList(db.city, "City_ID", "City", bookingCargo.City_ID);


            return View(bookingCargo);
        }

        // GET: bookingCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargo.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            return View(bookingCargo);
        }

        // POST: bookingCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookingCargo bookingCargo = db.bookingCargo.Find(id);
            db.bookingCargo.Remove(bookingCargo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
