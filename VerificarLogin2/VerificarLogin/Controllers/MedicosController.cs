using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VerificarLogin.Models;

namespace VerificarLogin.Controllers
{
    public class MedicosController : Controller
    {
        private UsuarioContext db = new UsuarioContext();

        // GET: Medicos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidades");
            return View();
        }

        // POST: Medicos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CRM,EspecialidadeId,Endereco,Bairro,Cidade,Estado,Telefone,Email,WebSite,AtendePorConvenio")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidades", medico.EspecialidadeId);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidades", medico.EspecialidadeId);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CRM,EspecialidadeId,Endereco,Bairro,Cidade,Estado,Telefone,Email,WebSite,AtendePorConvenio")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidades", medico.EspecialidadeId);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Busca()
        {
            var medicos = db.Medicos.Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        [HttpPost]
        public ActionResult Busca(string texto)
        {

            var consulta = (from C in db.Medicos.Include(m=> m.Especialidade)
                            where C.Nome.Contains(texto)
                            orderby C.Id ascending
                            select C);


            return View(consulta.ToList());
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
