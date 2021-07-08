using Quizz.Mvc.Web.Models;
using Quizz.Mvc.Web.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quizz.Mvc.Web.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question

        private readonly QuestionService questionService = new QuestionService();


        // GET: Question
        public async Task<ActionResult> Index()
        {
            var list = await questionService.GetAll();
            return View(list);
        }

        // GET: Question/Details/{id}
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var question = await questionService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Question question)
        {
            if (ModelState.IsValid)
            {
                await questionService.Create(question);

                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: Question/Edit/{id}
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var question = await questionService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        //POST: Question/Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                await questionService.Update(question.Id, question);

                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Question/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = await questionService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await questionService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}