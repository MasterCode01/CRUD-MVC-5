using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.entity;

namespace model.dao
{
    public class AlumnoDao:Obligatorio<Alumno>
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public AlumnoDao()
        {
            objConexion = Conexion.saberEstado();
        }

        public void create(Alumno objAlumno)
        {
            string create = "insert into alumno(idAlumno,nombre,apellido,telefono)values('"+ objAlumno.IdAlumno+ "','"+ objAlumno.Nombre+ "','" + objAlumno.Apellido + "','" + objAlumno.Telefono + "')";
            try
            {
                comando = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void update(Alumno objAlumno)
        {
            string update = "update  alumno set nombre='"+objAlumno.Nombre+ "',apellido='" + objAlumno.Apellido + "',telefono='" + objAlumno.Telefono + "' where idAlumno='" + objAlumno.IdAlumno + "'";
            try
            {
                comando = new SqlCommand(update, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void delete(Alumno objAlumno)
        {
            string delete = "delete from alumno where idAlumno='" + objAlumno.IdAlumno + "'";
            try
            {
                comando = new SqlCommand(delete, objConexion.getCon());
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public bool find(Alumno objAlumno)
        {

            bool hayRegistros;
            string find = "select*from alumno where idAlumno='" + objAlumno.IdAlumno + "' ";

            try
            {
                comando = new SqlCommand(find, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                hayRegistros = read.Read();
                if (hayRegistros)
                {
                    objAlumno.IdAlumno = Convert.ToInt32(read[0].ToString());
                    objAlumno.Nombre = read[1].ToString();
                    objAlumno.Apellido = read[2].ToString();
                    objAlumno.Telefono = read[3].ToString();

                    objAlumno.Estado = 99;
                }
                else
                {
                    objAlumno.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return hayRegistros;
        }

        public List<Alumno> findAll()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            string findAll = "select*from alumno";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Alumno objAlumno = new Alumno();
                    objAlumno.IdAlumno = Convert.ToInt32(read[0].ToString());
                    objAlumno.Nombre = read[1].ToString();
                    objAlumno.Apellido = read[2].ToString();
                    objAlumno.Telefono = read[3].ToString();
                    listaAlumnos.Add(objAlumno);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return listaAlumnos;
        }
    }
}
