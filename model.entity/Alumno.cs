using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.entity
{
    public class Alumno
    {
        //creamos los atributos de la clase
        private int idAlumno;
        private string nombre;
        private string apellido;
        private string telefono;
        //agregamos un esta para controlar los errores
        private int estado;

        public int IdAlumno
        {
            get
            {
                return idAlumno;
            }

            set
            {
                idAlumno = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public Alumno()
        {

        }
        public Alumno(int idAlumno)
        {
            this.IdAlumno = idAlumno;
        }
        public Alumno(int idAlumno,string nombre,string apellido,string telefono)
        {
            this.IdAlumno = idAlumno;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
        }

        //GETERS

    }
}
