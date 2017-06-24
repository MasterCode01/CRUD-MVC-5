using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.entity;
using model.neg;

namespace webMvc5.Controllers
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

        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicio();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alumno objAlumno)
        {
            //me quede aqui
            mensajeInicio();
            objAlumnoNeg.create(objAlumno);
            mensajeErrorRegistro(objAlumno);
            return View();
        }
        public void mensajeInicio()
        {
            ViewBag.mensajeInicio = "Formulario de Registro de Alumnos";
        }

        public void mensajeErrorRegistro(Alumno objAlumno)
        {
            switch (objAlumno.Estado)
            {
                case 10:
                    ViewBag.mensajeError = "Campo Codigo Esta Vacio";
                    break;

                case 1:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo idCliente,solo se permite numeros menores que 100 y mayores que 10";
                    break;

                case 100:
                    ViewBag.mensajeError = "solo se permiten numeros";
                    break;

                case 20:
                    ViewBag.mensajeError = "Campo Nombre Esta Vacio";
                    break;

                case 2:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo nombre,solo se permiten 50 caracteres";
                    break;

                case 30:
                    ViewBag.mensajeError = "Campo Apellido Esta Vacio";
                    break;

                case 3:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo Apellido,solo se permiten 50 caracteres";
                    break;

                case 40:
                    ViewBag.mensajeError = "Campo Telefono Esta Vacio";
                    break;

                case 4:
                    ViewBag.mensajeError = "Excedio la longitud de la cadena en el campo Telefono,solo se permiten 12 caracteres";
                    break;

                case 5:
                    ViewBag.mensajeError = "Alumno ["+objAlumno.IdAlumno+"]ya esta registrado";
                    break;

                case 99:
                    ViewBag.mensajeExito = "Alumno [" + objAlumno.IdAlumno + "]fue registrado con exito";
                    break;



            }
        }



        public ActionResult Find(string codigo)
        {
            Alumno objALumno = new Alumno(Convert.ToInt32(codigo));
            objAlumnoNeg.find(objALumno);

            return View(objALumno);
        }

    }
}