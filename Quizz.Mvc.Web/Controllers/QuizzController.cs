using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FilRouge.DAL.AccessLayers;
using FilRouge.DAL.Context;
using FilRouge.DAL.Models;

namespace Quizz.Mvc.Web.Controllers
{
    public class QuizzController : Controller
    {
        //private QuizzContext db = new QuizzContext();
        private readonly AdministrateurAccessLayer administrateurAcessLayer = new AdministrateurAccessLayer();
        private readonly CandidatAccessLayer candidatAccessLayer = new CandidatAccessLayer();
        private readonly QuestionAccessLayer questionAccessLayer = new QuestionAccessLayer();
        private readonly QuizzAccessLayer quizzAccessLayer = new QuizzAccessLayer();
        private readonly RecruteurAccessLayer recruteurAccessLayer = new RecruteurAccessLayer();

        // GET: Quizz
        public ActionResult Index()
        {
            return View(quizzAccessLayer.GetAll());
        }

        // GET: Quizz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quizz = quizzAccessLayer.Get((int)id);
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
        public async Task<ActionResult> Create(QuizzClass quizz)
        {
            if (ModelState.IsValid)
            {
                await quizzAccessLayer.AddAsync(quizz).ConfigureAwait(false);

                return RedirectToAction("Index");
            }

            return View(quizz);
        }

        //// GET: Quizz/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quizz quizz = db.Quizzs.Find(id);
        //    if (quizz == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizz);
        //}

        //// POST: Quizz/Edit/5
        //// Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //// plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,NbDeQuestions,Depart,Fin,Note,Niveau")] Quizz quizz)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(quizz).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(quizz);
        //}

        //// GET: Quizz/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quizz quizz = db.Quizzs.Find(id);
        //    if (quizz == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizz);
        //}

        //// POST: Quizz/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Quizz quizz = db.Quizzs.Find(id);
        //    db.Quizzs.Remove(quizz);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
