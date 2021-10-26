using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EscuelaCovid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : Controller
    {
        [HttpGet("GuardarUsuario")]
        public string GuardarUsuario(string Nombre, string AP, string AM, string Usuario, string Contraseña)
        {
            var almacenar = new StorageSQL();
            bool resultado = almacenar.GuardarUsuarios(Nombre, AP, AM, Usuario, Contraseña);
            if (resultado == true)
                return "Almacenado en SQL server desde .Net Core 5";
            else
                return "No Almacenado";
        }
        [HttpGet("MostrarUsuarios")]
        public JsonResult MostrarUsuarios()
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.MostrarUsuarios();
            return Json(Lista);
        }
        [HttpGet("BuscarUsuario")]
        public JsonResult BuscarUsuario(string usuario)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.BuscarrUsuarios(usuario);
            return Json(Lista);
        }
        [HttpGet("MostrarAlumnos")]
        public JsonResult MostrarAlumnos()
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.MostrarAlumnos();
            return Json(Lista);
        }
        [HttpGet("BuscarAlumnos")]
        public JsonResult MostrarAlumnos(string Matricula)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.BuscarAlumnos(Matricula);
            return Json(Lista);
        }
        [HttpGet("MostrarSintomas")]
        public JsonResult MostrarSintomas(string Fecha, string Sintomas, string Asiste, string Matricula)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.MostrarSintomas(Fecha,Sintomas,Asiste,Matricula);
            return Json(Lista);
        }
        [HttpGet("MostrarHijos")]
        public JsonResult MostrarHijos(int id)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.MostrarHijos(id);
            return Json(Lista);
        }
        [HttpGet("GuardarAlumno")]
        public string GuardarAlumno(string Matricula, string Nombre, string AP, string AM, string Grado, string Grupo, int edad, int FkUsuario)
        {
            var almacenar = new StorageSQL();
            bool resultado = almacenar.GuardarAlumno(Matricula,Nombre,AP,AM,Grado,Grupo,edad,FkUsuario);
            if (resultado == true)
                return "Almacenado en SQL server desde .Net Core 5";
            else
                return "No Almacenado";
        }
        [HttpGet("GuardarSintomas")]
        public string GuardarSintomas(string FkAlumno, double temp, string Sintomas, string observaciones, string Asistenacia)
        {
            var almacenar = new StorageSQL();
            bool resultado = almacenar.GuardarSintomas(FkAlumno,temp,Sintomas,observaciones,Asistenacia);
            if (resultado == true)
                return "Almacenado en SQL server desde .Net Core 5";
            else
                return "No Almacenado";
        }
        [HttpGet("Login")]
        public JsonResult Login()
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.Login();
            return Json(Lista);
        }
        [HttpGet("NombreAlumnos")]
        public JsonResult NombreAlumnos(int Fkusuario)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.NombreAlumnos(Fkusuario);
            return Json(Lista);
        }
    }
}
