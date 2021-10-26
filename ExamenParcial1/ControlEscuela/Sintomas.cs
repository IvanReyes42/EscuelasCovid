using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlEscuela
{
    public class Sintomas
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Alumno { get; set; }
        public double Temperatura { get; set; }
        public string PresentaSintomas { get; set; }
        public string Observaciones { get; set; }
        public string Asistencia { get; set; }
    }
}