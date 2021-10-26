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
    public partial class ControlUsuarios : System.Web.UI.Page
    {
        public List<Usuarios> ListaUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre, AP, AM, User, Contraseña;
            var InsertarUsuario = new ServicioWeb.ServicioWebEscuela();
            try
            {
                Nombre = txtNombre.Text;
                AP = txtAP.Text;
                AM = txtAM.Text;
                User = txtUser.Text;
                Contraseña = txtPassword.Text;
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/GuardarUsuario?Nombre=" +
                    Nombre+"&AP="+AP+"&AM="+AM+"&Usuario="+User+"&Contraseña="+Contraseña+"";
                var request = (HttpWebRequest)WebRequest.Create(API);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();
                
                if (responseText.ToString().Equals("Almacenado en SQL server desde .Net Core 5"))
                {
                    lblMensaje.Text = "Usuario Agregado Correctamente";
                    Limpiar();
                       
                }
                else
                {
                    lblMensaje.Text = "Error al Guardar Nuevo Usuario";
                    txtNombre.Focus();
                }
                   
            }
            catch (Exception)
            {

                lblMensaje.Text = "Error al Ingresar datos";
            }
        }
        public void Limpiar()
        {
            txtNombre.Text = "";
            txtAP.Text = "";
            txtAM.Text = "";
            txtPassword.Text = "";
            txtUser.Text = "";
        }
        public async void Llenar()
        {
            
            try
            {
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/MostrarUsuarios";
                JsonValue json = await Datos(API);
                Transform(json);
                dvgUsuarios.AutoGenerateColumns = true;
                dvgUsuarios.DataSource = ListaUsuarios;
                dvgUsuarios.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
            }
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            string Busqueda;
            try
            {
               
                Busqueda = txtBUsuario.Text;
                var API = "https://api-restescuelacovid.azurewebsites.net//Principal/BuscarUsuario?usuario="+Busqueda+"";
                JsonValue json = await Datos(API);
                Transform(json);
                dvgUsuarios.AutoGenerateColumns = true;
                dvgUsuarios.DataSource = ListaUsuarios;
                dvgUsuarios.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text="Error al consultar dato";
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
                ListaUsuarios = new List<Usuarios>();
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Usuarios u = new Usuarios();
                    u.IdUsuario = Resultados["idUsuario"];
                    u.Nombre = Resultados["nombre"];
                    u.ApellidoPaterno = Resultados["apellidoPaterno"];
                    u.ApellidoMaterno = Resultados["apellidoMaterno"];
                    u.Usuario = Resultados["usuario"];
                    ListaUsuarios.Add(u);

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los datos";
            }
        }

    }
}