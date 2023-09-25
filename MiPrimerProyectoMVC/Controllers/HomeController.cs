using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MiPrimerProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        private Alumno alumno = new Alumno();
        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.Alumnos = Alumno.Listar();
            return View(alumno.Listar());
        }
        public ActionResult Ver(int id)
        {

            return View(alumno.Obtener(id));
        }

        public ActionResult Guardar(Alumno alumno, int[] algo)
        {

            return Redirect("~/home/index");
        }
    }
}