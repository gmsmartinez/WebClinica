using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClinica.Models;

namespace WebClinica.Controllers
{
    public class MedicoController : Controller
    {
        ClinicaDBContext context = new ClinicaDBContext();
        // GET: Medico
        public ActionResult Index()
        {
            List<Medico> list = context.Medicos.ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();

            return View(medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", medico);
            }
        }

        public ActionResult Delete(int id)
        {
            Medico medico = context.Medicos.Find(id);
            if (medico != null)
            {
                return View("Delete", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Medicos.Remove(medico);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var medico = (from m in context.Medicos
                          where m.Id == id
                          select m).SingleOrDefault();

            return View("Edit", medico);
        }

        [HttpPost]
        public ActionResult Edit(Medico medicoModi)
        {
            if (ModelState.IsValid)
            {
                var medicoOrigen =
                    context.Medicos.SingleOrDefault(m => m.Id == medicoModi.Id);

                medicoOrigen.Nombre = medicoModi.Nombre;
                medicoOrigen.Apellido = medicoModi.Apellido;
                medicoOrigen.Matricula = medicoModi.Matricula;
                medicoOrigen.Especialidad = medicoModi.Especialidad;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(medicoModi);
            }
        }

        public ActionResult Detail(int id)
        {
            Medico medico = context.Medicos.Find(id);
            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }

        }
    }
}