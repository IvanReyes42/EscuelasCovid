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
using ConexionEscuela;

namespace ControlEscuela
{
    public partial class ControlSintomas : System.Web.UI.Page
    {
        public List<Sintomas> ListaSintomas;
        protected void Page_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            string Fecha, Matricula;
            var MostrarSintomas = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Fecha = txtFecha.Text;
               
                Matricula = txtMatricula.Text;

                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/MostrarSintomas?Fecha="+
                    Fecha+"&Sintomas=&Asiste=&Matricula="+Matricula+"";
                JsonValue json = await Datos(API);
                Transform(json);
                dvgSintomas.AutoGenerateColumns = true;
                dvgSintomas.DataSource = ListaSintomas;
                dvgSintomas.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
            }
        }
        public async void Llenar()
        {
            
            try
            {
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/MostrarSintomas?Fecha=&Sintomas=&Asiste=&Matricula=";
                JsonValue json = await Datos(API);
                Transform(json);
                dvgSintomas.AutoGenerateColumns = true;
                dvgSintomas.DataSource = ListaSintomas;
                dvgSintomas.DataBind();
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
                ListaSintomas = new List<Sintomas>();
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Sintomas s = new Sintomas();
                    s.Id = Resultados["id"];
                    s.Fecha = Resultados["fecha"];
                    s.Alumno = Resultados["alumno"];
                    s.Temperatura = Resultados["temperatura"];
                    s.PresentaSintomas = Resultados["presentaSintomas"];
                    s.Observaciones = Resultados["observaciones"];
                    s.Asistencia = Resultados["asistencia"];
                    ListaSintomas.Add(s);

                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al cargar los datos";
            }
        }
    }
}