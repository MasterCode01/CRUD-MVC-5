using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.dao;
using model.entity;

namespace model.neg
{
    public class AlumnoNeg
    {

        private AlumnoDao objAlumnoDao;
        public AlumnoNeg()
        {
            objAlumnoDao = new AlumnoDao();
        }
        public void create(Alumno objAlumno)
        {
            bool verificacion;
            //validar idAlumno estado=1
            string codigo = objAlumno.IdAlumno.ToString();
            int idAlumno = 0;
            if (codigo == null)
            {
                objAlumno.Estado = 10;
                return;
            }
            else
            {
                try {
                    idAlumno = Convert.ToInt32(objAlumno.IdAlumno);
                    verificacion = idAlumno >= 10 && idAlumno <= 99;
                    if (!verificacion)
                    {
                        objAlumno.Estado = 1;
                        return;
                    }

                } catch (Exception e) {
                    objAlumno.Estado = 100;
                }
            }

            //validar Nombre Alumno estado=2
            string nombre = objAlumno.Nombre;
            if (nombre == null)
            {
                objAlumno.Estado = 20;
                return;
            }
            else
            {
                nombre = objAlumno.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 2;
                    return;
                }
            }
            //Validar Apellido Alumno estado=3
            string apellido = objAlumno.Apellido;
            if (apellido == null)
            {
                objAlumno.Estado = 30;
                return;
            }
            else
            {
                apellido = objAlumno.Apellido.Trim();
                verificacion = apellido.Length > 0 && apellido.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 3;
                    return;
                }
            }
            //validar Telefono Alumno estado=4
            string telefono = objAlumno.Telefono;
            if (telefono == null)
            {
                objAlumno.Estado = 40;
                return;
            }
            else
            {
                telefono = objAlumno.Telefono.Trim();
                verificacion = telefono.Length > 0 && telefono.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 4;
                    return;
                }
            }

            //validar que no exista idAlumno repetido estado=5
            Alumno objAlumnoAux = new Alumno();
            objAlumnoAux.IdAlumno = objAlumno.IdAlumno;
            verificacion = !objAlumnoDao.find(objAlumnoAux);
            if (!verificacion)
            {
                objAlumno.Estado = 5;
                return;
            }
            objAlumno.Estado = 99;
            objAlumnoDao.create(objAlumno);

        }

        public void update(Alumno objAlumno)
        {
            bool verificacion;
            
            //validar Nombre Alumno estado=2
            string nombre = objAlumno.Nombre;
            if (nombre == null)
            {
                objAlumno.Estado = 20;
                return;
            }
            else
            {
                nombre = objAlumno.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 2;
                    return;
                }
            }
            //Validar Apellido Alumno estado=3
            string apellido = objAlumno.Apellido;
            if (apellido == null)
            {
                objAlumno.Estado = 30;
                return;
            }
            else
            {
                apellido = objAlumno.Apellido.Trim();
                verificacion = apellido.Length > 0 && apellido.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 3;
                    return;
                }
            }
            //validar Telefono Alumno estado=4
            string telefono = objAlumno.Telefono;
            if (telefono == null)
            {
                objAlumno.Estado = 40;
                return;
            }
            else
            {
                telefono = objAlumno.Telefono.Trim();
                verificacion = telefono.Length > 0 && telefono.Length <= 50;
                if (!verificacion)
                {
                    objAlumno.Estado = 4;
                    return;
                }
            }
                        
            objAlumno.Estado = 99;
            objAlumnoDao.update(objAlumno);

        }

        public void delete(Alumno objAlumno)
        {
            bool verificacion;
            Alumno objAlumnoAux = new Alumno();
            objAlumnoAux.IdAlumno = objAlumno.IdAlumno;
            verificacion = objAlumnoDao.find(objAlumnoAux);
            if (!verificacion)
            {
                objAlumno.Estado = 33;
                return;
            }
            objAlumno.Estado = 99;
            objAlumnoDao.delete(objAlumno);
        }

        public bool find(Alumno objAlumno)
        {
            return objAlumnoDao.find(objAlumno);
        }

        public List<Alumno> findAll()
        {
            return objAlumnoDao.findAll();
        }
    }
}
