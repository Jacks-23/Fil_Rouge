using Quizz.Mvc.Web.Models;
using Quizz.Mvc.Web.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quizz.Mvc.Web.Controllers
{
    public class AdministrateurController : Controller
    {
        // GET: Administrateur
   
        private readonly AdministrateurService administrateurService = new AdministrateurService();

        // GET: Adminisstrateur
        public async Task<ActionResult> Index()
        {
            var list = await administrateurService.GetAll();
            return View(list);
        }

        // GET: Administrateur/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var admin = await administrateurService.Get((int)id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Administrateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public async Task<ActionResult> Create(Administrateur admin)
        {
            if (ModelState.IsValid)
            {
                await administrateurService.Create(admin);

                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Administrateur/Edit/{id}
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var admin = await administrateurService.Get((int)id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: Administrateur/Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Administrateur admin)
        {
            if (ModelState.IsValid)
            {
                await administrateurService.Update(admin.Id, admin);

                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Administrateur/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var admin= await administrateurService.Get((int)id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        // POST: Administrateur/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await administrateurService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}