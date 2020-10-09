using professorProva.Context;
using professorProva.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace professorProva.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.Professores.ToList());
        }

        #region Create - GET
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(ProfessorModel professor)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(professor);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }
        #endregion

        #region Details 
        [HttpGet]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel professor = db.Professores.Where(a => a.Id == id).FirstOrDefault();
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel professor = db.Professores.Where(a => a.Id == id).FirstOrDefault();
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }
        #endregion

        #region Edit - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfessorModel professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel professor = db.Professores.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessorModel professor = db.Professores.Find(id);
            db.Professores.Remove(professor);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}