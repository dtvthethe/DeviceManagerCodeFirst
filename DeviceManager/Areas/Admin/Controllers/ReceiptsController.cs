using DeviceManager.Models;
using DeviceManager.Models.DB;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DeviceManager.Areas.Admin.Controllers
{
    public class ReceiptsController : Controller
    {
        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        // GET: Admin/Receipts
        public async Task<ActionResult> Index()
        {
            var receipts = db.Receipts.Include(r => r.Provider);
            return View(await receipts.ToListAsync());
        }

        // GET: Admin/Receipts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = await db.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Admin/Receipts/Create
        public ActionResult Create()
        {
            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name");
            return View();
        }

        // POST: Admin/Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDProvider,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipts.Add(receipt);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            return View(receipt);
        }

        // GET: Admin/Receipts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = await db.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            return View(receipt);
        }

        // POST: Admin/Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDProvider,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDProvider = new SelectList(db.Providers, "ID", "Name", receipt.IDProvider);
            return View(receipt);
        }

        // GET: Admin/Receipts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = await db.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Admin/Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Receipt receipt = await db.Receipts.FindAsync(id);
            db.Receipts.Remove(receipt);
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
