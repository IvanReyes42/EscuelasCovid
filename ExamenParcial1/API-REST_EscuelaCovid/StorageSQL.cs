using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EscuelaCovid
{
    public class StorageSQL
    {
        List<Usuarios> ListaUsuario;
        List<Alumnos> ListaAlumnos;
        List<Sintomas> ListaSintomas;
        public bool GuardarUsuarios(string Nombre, string AP, string AM, string Usuario, string Contraseña)
        {
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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
        public List<Usuarios> MostrarUsuarios()
        {
            var dt = new DataTable();
            ListaUsuario = new List<Usuarios>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
            try
            {
                var consultar = new SqlCommand("EXEC MostrarUsuarios", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuarios u = new Usuarios();
                    u.IdUsuario = int.Parse(dt.Rows[i]["IdUsuario"].ToString());
                    u.Nombre = dt.Rows[i]["Nombre"].ToString();
                    u.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                    u.Usuario = dt.Rows[i]["Usuario"].ToString();
                    ListaUsuario.Add(u);
                }
                return ListaUsuario;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaUsuario;
                throw;
            }
        }

        public List<Usuarios> BuscarrUsuarios(string usuario)
        {
            var dt = new DataTable();
            ListaUsuario = new List<Usuarios>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
          
            try
            {
                var consultar = new SqlCommand("EXEC BusquedaUsuario'" + usuario + "'", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuarios u = new Usuarios();
                    u.IdUsuario = int.Parse(dt.Rows[i]["IdUsuario"].ToString());
                    u.Nombre = dt.Rows[i]["Nombre"].ToString();
                    u.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                    u.Usuario = dt.Rows[i]["Usuario"].ToString();
                    ListaUsuario.Add(u);
                }
                return ListaUsuario;

            }
            catch (Exception)
            {
                conexion.Close();
                return ListaUsuario;
                throw;
            }
        }
        public List<Alumnos> MostrarAlumnos()
        {
            var dt = new DataTable();
            ListaAlumnos = new List<Alumnos>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
            try
            {
                var consultar = new SqlCommand("EXEC MostrarAlumnos", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alumnos a = new Alumnos();
                    a.Matricula = dt.Rows[i]["Matricula"].ToString();
                    a.Nombre = dt.Rows[i]["Nombre"].ToString();
                    a.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                    a.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                    a.Grado = dt.Rows[i]["Grado"].ToString();
                    a.Grupo = dt.Rows[i]["Grupo"].ToString();
                    a.Edad = int.Parse(dt.Rows[i]["Edad"].ToString());
                    a.PadreDeFamilia = dt.Rows[i]["PadreDeFamilia"].ToString();
                    ListaAlumnos.Add(a);
                }
                return ListaAlumnos;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaAlumnos;
                throw;
            }
        }

        public List<Alumnos> BuscarAlumnos(string Matricula)
        {
            var dt = new DataTable();
            ListaAlumnos = new List<Alumnos>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
       
            try
            {
                var consultar = new SqlCommand("EXEC BuscarAlumno'" + Matricula + "'", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alumnos a = new Alumnos();
                    a.Matricula = dt.Rows[i]["Matricula"].ToString();
                    a.Nombre = dt.Rows[i]["Nombre"].ToString();
                    a.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                    a.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                    a.Grado = dt.Rows[i]["Grado"].ToString();
                    a.Grupo = dt.Rows[i]["Grupo"].ToString();
                    a.Edad = int.Parse(dt.Rows[i]["Edad"].ToString());
                    a.PadreDeFamilia = dt.Rows[i]["PadreDeFamilia"].ToString();
                    ListaAlumnos.Add(a);
                }
                return ListaAlumnos;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaAlumnos;
                throw;
            }
        }
        public List<Sintomas> MostrarSintomas(string Fecha, string Sintomas, string Asiste, string Matricula)
        {
            var dt = new DataTable();
            ListaSintomas = new List<Sintomas>();

            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
            try
            {
                var consultar = new SqlCommand("EXEC MostrarSintomas'" + Fecha + "','" + Sintomas + "','" + Asiste + "','" + Matricula + "'", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sintomas s = new Sintomas();
                    s.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                    s.Fecha = dt.Rows[i]["Fecha"].ToString();
                    s.Temperatura = double.Parse(dt.Rows[i]["Temperatura"].ToString());
                    s.PresentaSintomas = dt.Rows[i]["PresentaSintomas"].ToString();
                    s.Asistencia = dt.Rows[i]["Asistencia"].ToString();
                    s.Observaciones = dt.Rows[i]["Observaciones"].ToString();
                    s.Alumno = dt.Rows[i]["Alumno"].ToString();
                    ListaSintomas.Add(s);

                }
                return ListaSintomas;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaSintomas;
                throw;
            }
        }
        public List<Alumnos> MostrarHijos(int id)
        {
            var dt = new DataTable();
            ListaAlumnos = new List<Alumnos>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
            try
            {
                var consultar = new SqlCommand("EXEC MostrarHijos '" + id + "'", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alumnos a = new Alumnos();
                    a.Matricula = dt.Rows[i]["Matricula"].ToString();
                    a.Nombre = dt.Rows[i]["Nombre"].ToString();
                    a.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                    a.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                    a.Grado = dt.Rows[i]["Grado"].ToString();
                    a.Grupo = dt.Rows[i]["Grupo"].ToString();
                    a.Edad = int.Parse(dt.Rows[i]["Edad"].ToString());
                    
                    ListaAlumnos.Add(a);
                }
                return ListaAlumnos;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaAlumnos;
                throw;
            }
        }
        public bool GuardarAlumno(string Matricula, string Nombre, string AP, string AM, string Grado, string Grupo, int edad, int FkUsuario)
        {
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            try
            {
                var Insertar = new SqlCommand("Exec GuardarAlumnos '" + Matricula + "','" + Nombre + "','" + AP + "','" + AM + "','" + Grado + "','" + Grupo + "','" + edad + "','" + FkUsuario + "'", conexion);
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
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
        public List<Usuarios> Login()
        {
            var dt = new DataTable();
            ListaUsuario = new List<Usuarios>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
            try
            {
                var consultar = new SqlCommand("EXEC InicioSesion", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuarios u = new Usuarios();
                    u.IdUsuario = int.Parse(dt.Rows[i]["IdUsuario"].ToString());
                    u.Usuario = dt.Rows[i]["Usuario"].ToString();
                    u.Contraseña = dt.Rows[i]["Contraseña"].ToString();
                    ListaUsuario.Add(u);
                }
                
                return ListaUsuario;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaUsuario;
                throw;
            }
        }
        public List<Alumnos> NombreAlumnos(int Fkusuario)
        {
            var dt = new DataTable();
            ListaAlumnos = new List<Alumnos>();
            var conexion = new SqlConnection
             ("Server=tcp:ivanreyes.database.windows.net,1433;Initial Catalog=EscuelasCovid;Persist Security Info=False;User ID=ivereyes;Password=Ideal1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var conjunto = new DataSet();
            try
            {
                var consultar = new SqlCommand("EXEC NombreAlumnos '" + Fkusuario + "'", conexion);
                conexion.Open();
                var da = new SqlDataAdapter(consultar);
                da.Fill(dt);
                conexion.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alumnos a = new Alumnos();
                    a.Matricula = dt.Rows[i]["Matricula"].ToString();
                    a.Nombre = dt.Rows[i]["Alumno"].ToString();
                   

                    ListaAlumnos.Add(a);
                }

                return ListaAlumnos;
            }
            catch (Exception)
            {
                conexion.Close();
                return ListaAlumnos;
                throw;
            }
        }
    }
}
