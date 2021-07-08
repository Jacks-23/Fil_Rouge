using Quizz.Mvc.Web.Models;
using Quizz.Mvc.Web.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quizz.Mvc.Web.Controllers
{
    public class RecruteurController : Controller
    {
        // GET: Recruteur

        private readonly RecruteurService recruteurService = new RecruteurService();

        // GET: Recruteur
        public async Task<ActionResult> Index()
        {
            var list = await recruteurService.GetAll().ConfigureAwait(false);
            return View(list);
        }

        // GET: Recruteur/Details/{id}
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recruteur = await recruteurService.Get((int)id);
            if (recruteur == null)
            {
                return HttpNotFound();
            }
            return View(recruteur);
        }

        // GET: Recruteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recruteur/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Recruteur recruteur)
        {
            if (ModelState.IsValid)
            {
                await recruteurService.Create(recruteur);

                return RedirectToAction("Index");
            }
            return View(recruteur);
        }

        // GET: Recruteur/Edit/{id}
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Recruteur recruteur = await recruteurService.Get((int)id);
            if(recruteur == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: Recruteur/Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Recruteur recruteur)
        {
            if (ModelState.IsValid)
            {
                await recruteurService.Update(recruteur.Id, recruteur);

                return RedirectToAction("Index");
            }

            return View(recruteur);
        }

        // GET: Recruteur/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Recruteur recruteur = await recruteurService.Get((int)id);
            if (recruteur == null)
            {
                return HttpNotFound();
            }

            return View(recruteur);
        }

        // POST: Recruteur/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await recruteurService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }

}