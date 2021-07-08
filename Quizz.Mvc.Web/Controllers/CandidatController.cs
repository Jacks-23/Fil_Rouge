using Quizz.Mvc.Web.Models;
using Quizz.Mvc.Web.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quizz.Mvc.Web.Controllers
{
    public class CandidatController : Controller
    {
        // GET: Candidat

        private readonly CandidatService candidatService = new CandidatService();

        // GET: Candidat
        public async Task<ActionResult> Index()
        {
            var list = await candidatService.GetAll();
            return View(list);
        }

        // GET : Candidat/Details/{id}
        public async Task<ActionResult> Details(int? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var candidat = await candidatService.Get((int)id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        //GET : Candidat/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Candidat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                await candidatService.Create(candidat);

                return RedirectToAction("Index");
            }

            return View(candidat);
        }

        //GET: Candidat/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        //POST : Candidat/Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Candidat candidat)
        {
            if(ModelState.IsValid)
            {
                await candidatService.Update(candidat.Id, candidat);

                return RedirectToAction("Index");
            }

            return View(candidat);
        }

        // GET : Candidat/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Candidat candidat = await candidatService.Get((int)id);
            if (candidat == null)
            {
                return HttpNotFound();
            }

            return View(candidat);
        }

        // POST: Candidat/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await candidatService.Delete(id).ConfigureAwait(false);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}