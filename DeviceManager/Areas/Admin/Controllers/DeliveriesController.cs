using DeviceManager.Models;
using DeviceManager.Models.DB;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DeviceManager.Areas.Admin.Controllers
{
    public class DeliveriesController : Controller
    {
        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        // GET: Admin/Deliveries
        public async Task<ActionResult> Index()
        {
            var productCategories = db.ProductCategories.Include(d => d.UserDeliveryFrom).Include(d => d.UserDeliveryTo);
            return View(await productCategories.ToListAsync());
        }

        // GET: Admin/Deliveries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.ProductCategories.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Admin/Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password");
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password");
            return View();
        }

        // POST: Admin/Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DeliveryToUser,DeliveryFromUser,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(delivery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // GET: Admin/Deliveries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.ProductCategories.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // POST: Admin/Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DeliveryToUser,DeliveryFromUser,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // GET: Admin/Deliveries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = await db.ProductCategories.FindAsync(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Admin/Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Delivery delivery = await db.ProductCategories.FindAsync(id);
            db.ProductCategories.Remove(delivery);
            await db.SaveChangesAsync();
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
