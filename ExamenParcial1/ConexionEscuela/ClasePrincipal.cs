using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionEscuela
{
    public class ClasePrincipal
    {

        public bool GuardarUsuarios(string Nombre, string AP, string AM, string Usuario, String Contraseña)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            
            try
            {
                var Insertar = new SqlCommand("Exec GuardarUsuario '" + Nombre + "','" + AP + "','" + AM + "','" + Usuario + "','" + Contraseña + "'", conexion);
                conexion.Open();
                Insertar.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
                
            }
        }
        public DataSet MostrarUsuarios()
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC MostrarUsuarios", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Usuarios");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }

        public DataSet BuscarrUsuarios(string usuario)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC BusquedaUsuario'"+usuario+"'", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Usuarios");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
        public DataSet MostrarAlumnos()
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC MostrarAlumnos", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Alumnos");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }

        public DataSet BuscarAlumnos(string Matricula)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC BuscarAlumno'" + Matricula + "'", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Alumnos");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
        public DataSet MostrarSintomas(string Fecha, string Sintomas, string Asiste, string Matricula)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC MostrarSintomas'" + Fecha +"','"+Sintomas+"','"+Asiste+"','"+Matricula+"'", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Sintomas");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
        public DataSet MostrarHijos(int id)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC MostrarHijos '"+id+"'", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Alumnos");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
        public bool GuardarAlumno(string Matricula, string Nombre, string AP, string AM, string Grado, string Grupo, int edad, int FkUsuario)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            try
            {
                var Insertar = new SqlCommand("Exec GuardarAlumnos '" +Matricula+"','"+ Nombre + "','" + AP + "','" + AM + "','" + Grado + "','" + Grupo + "','"+edad+"','"+FkUsuario+"'", conexion);
                conexion.Open();
                Insertar.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        public bool GuardarSintomas(string FkAlumno, double temp, string Sintomas, string observaciones, string Asistenacia)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            try
            {
                var Insertar = new SqlCommand("Exec GuardarSintomas '" + FkAlumno + "','" + temp + "','" + Sintomas + "','" + observaciones + "','" + Asistenacia + "'", conexion);
                conexion.Open();
                Insertar.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        public DataSet Login()
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC InicioSesion", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Usuarios");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
        public DataSet NombreAlumnos(int Fkusuario)
        {
            var conexion = new SqlConnection
             ("data source=IVANREYESPC\\IVANREYES; Initial Catalog=EscuelasCovid; User ID=sa; Password=LaVacaLola42;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlDataAdapter("EXEC NombreAlumnos '"+Fkusuario+"'", conexion);
                conexion.Open();
                consultar.Fill(conjunto, "Alumnos");
                conexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                conexion.Close();
                return conjunto;
                throw;
            }
        }
    }
}
