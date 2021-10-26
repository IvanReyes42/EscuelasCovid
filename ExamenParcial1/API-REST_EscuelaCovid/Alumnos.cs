using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EscuelaCovid
{
    public class Alumnos
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public int Edad { get; set; }
        public int FkIdUsuario { get; set; }
        public string PadreDeFamilia { get; set; }

    }
}
