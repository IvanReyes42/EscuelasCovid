using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ConexionEscuela;

namespace ServicioWebEscuela
{
  
    public class servicioWebEscuelaWebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public bool GuardarUsuarios(string Nombre, string AP, string AM, string Usuario, String Contraseña)
        {
            try
            {
                var DLL = new ClasePrincipal();
                if (DLL.GuardarUsuarios(Nombre, AP, AM, Usuario, Contraseña))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                
            }
        }
        public DataSet MostrarUsuarios()
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.MostrarUsuarios();
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet BuscarrUsuarios(string usuario)
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.BuscarrUsuarios(usuario);
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet MostrarAlumnos()
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.MostrarAlumnos();
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet BuscarAlumnos(string Matricula)
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.BuscarAlumnos(Matricula);
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet MostrarSintomas(string Fecha, string Sintomas, string Asiste, string Matricula)
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.MostrarSintomas(Fecha,Sintomas,Asiste,Matricula);
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet MostrarHijos(int id)
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.MostrarHijos(id);
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public bool GuardarAlumno(string Matricula, string Nombre, string AP, string AM, string Grado, string Grupo, int edad, int FkUsuario)
        {
            try
            {
                var DLL = new ClasePrincipal();
                if (DLL.GuardarAlumno(Matricula, Nombre, AP, AM, Grado, Grupo, edad, FkUsuario)) 
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool GuardarSintomas(string FkAlumno, double temp, string Sintomas, string observaciones, string Asistenacia)
        {
            try
            {
                var DLL = new ClasePrincipal();
                if (DLL.GuardarSintomas(FkAlumno,temp,Sintomas,observaciones,Asistenacia))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public DataSet Login()
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.Login();
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
        public DataSet NombreAlumnos(int Fkusuario)
        {
            var DLL = new ClasePrincipal();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = DLL.NombreAlumnos(Fkusuario);
                return Conjunto;
            }
            catch (System.Exception ex)
            {

                return Conjunto;
            }
        }
    }
}
