using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.neg;
using model.entity;

namespace AppMvc5.Controllers
{
    public class AlumnoController : Controller
    {

        private AlumnoNeg objAlumnoNeg;
        public AlumnoController()
        {
            objAlumnoNeg = new AlumnoNeg();
        }

        // GET: Alumno
        public ActionResult Inicio()
        {
            List<Alumno> lista = objAlumnoNeg.findAll();
            return View(lista);
        }
    }
}