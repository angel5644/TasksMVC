using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksMVC.Models;
using TasksMVC.Services;

namespace TasksMVC.Controllers
{
    [HandleError]
    public class TareaController : Controller
    {
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
            // Agregar la nueva tarea
            administradorTareas.Agregar(tarea);

            return RedirectToAction("Listar");
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
            // Remover tarea, no implementada
            administradorTareas.Remover(id);

            return RedirectToAction("Listar");
        }
    }
}