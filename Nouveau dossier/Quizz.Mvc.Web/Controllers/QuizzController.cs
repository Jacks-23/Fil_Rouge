
using Quizz.Mvc.Web.Models;
using Quizz.Mvc.Web.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Quizz.Mvc.Web.Controllers
{
    public class QuizzController : Controller
    {
        private readonly QuizService quizService = new QuizService();

        // GET: Quizz
        public async Task<ActionResult> Index()
        {
            var list = await quizService.GetAll();
            return View(list);
        }

        // GET: Quizz/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quizz = await quizService.Get((int)id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }

        // GET: Quizz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizz/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,NbDeQuestions,Depart,Fin,Note,Niveau")] Quizz quizz)
        public async Task<ActionResult> Create(Quiz quizz)
        {
            if (ModelState.IsValid)
            {
                await quizService.Create(quizz);

                return RedirectToAction("Index");
            }

            return View(quizz);
        }

        // GET: Quizz/Edit/{id}
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quizzclass = await quizService.Get((int)id);
            if (quizzclass == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // POST: Quizz/Edit/{id}
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,NbDeQuestions,Depart,Fin,Note,Niveau")] Quizz quizz)
        public async Task<ActionResult> Edit(Quiz quizz)
        {
            if (ModelState.IsValid)
            {
                await quizService.Update(quizz.Id, quizz);

                return RedirectToAction("Index");
            }

            return View(quizz);
        }

        //// GET: Quizz/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quizzclass = await quizService.Get((int)id);
            if (quizzclass == null)
            {
                return HttpNotFound();
            }

            return View(quizzclass);
        }

        // POST: Quizz/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await quizService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }
    }
}
