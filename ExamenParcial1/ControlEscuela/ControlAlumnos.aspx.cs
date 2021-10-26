using ConexionEscuela;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlEscuela
{
    public partial class ControlAlumnos : System.Web.UI.Page
    {
        public List<Alumnos> ListaAlumnos;
        protected  void Page_Load(object sender, EventArgs e)
        {
            Llenar();
        }
        public ControlAlumnos()
        {
           
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            string Matricula;
           
            
            try
            {
                Matricula = txtMatricula.Text;
                
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/BuscarAlumnos?Matricula="+Matricula+"";
                JsonValue json = await Datos(API);
                Transform(json);

                dvgAlumnos.AutoGenerateColumns = true;
                dvgAlumnos.DataSource = ListaAlumnos;
                dvgAlumnos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void Llenar()
        {
            
            try
            {
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/MostrarAlumnos";
                JsonValue json = await Datos(API);
                Transform(json);

                dvgAlumnos.AutoGenerateColumns = true;
                dvgAlumnos.DataSource = ListaAlumnos;
                dvgAlumnos.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
            }
        }

        public async Task<JsonValue> Datos(string API)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri(API));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var jsondoc = await Task.Run(() => JsonValue.Load(stream));
                    return jsondoc;
                }
            }
        }
        public void Transform(JsonValue json)
        {
            try
            {
                ListaAlumnos = new List<Alumnos>();
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Alumnos a = new Alumnos();
                    a.Matricula = Resultados["matricula"];
                    a.Nombre = Resultados["nombre"];
                    a.ApellidoPaterno = Resultados["apellidoPaterno"];
                    a.ApellidoMaterno = Resultados["apellidoMaterno"];
                    a.Grado = Resultados["grado"];
                    a.Grupo = Resultados["grupo"];
                    a.Edad = Resultados["edad"];
                    a.PadreDeFamilia = Resultados["padreDeFamilia"];
                    ListaAlumnos.Add(a);

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los datos";
            }
        }

    }
}