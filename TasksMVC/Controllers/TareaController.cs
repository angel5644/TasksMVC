using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksMVC.Models;
using TasksMVC.Services;

namespace TasksMVC.Controllers
{
    public class TareaController : Controller
    {
        // Continuar aquí, resolver problema de guardar tareas temporalmente
        private AdministradorTareas administradorTareas;

        public TareaController()
        {
            administradorTareas = new AdministradorTareas(System.Web.HttpContext.Current.Session);
        }

        // GET: Tarea
        public ActionResult Listar()
        {
            var listaTareas = administradorTareas.ObtenerTodas();

            return View(listaTareas);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                // Agregar la nueva tarea
                administradorTareas.Agregar(tarea);

                return RedirectToAction("Listar");
            }

            return View(tarea);
        }

        [HttpGet]
        public ActionResult Completar(int id)
        {
            // Completar tarea
            administradorTareas.Completar(id);

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            // Remover tarea
            administradorTareas.Remover(id);

            return RedirectToAction("Listar");
        }
    }
}