using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConexionEscuela;

namespace ControlEscuela
{
    public partial class ControlUsuarios : System.Web.UI.Page
    {
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
                if(InsertarUsuario.GuardarUsuarios(Nombre,AP,AM,User,Contraseña))
                {
                    lblMensaje.Text = "Usuario Agregado Correctamente";
                    Limpiar();
                    Llenar();
                }
                else
                {
                    lblMensaje.Text = "Error en la conexión Consultar a sistemas";
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
        public void Llenar()
        {
            var MostrarUsuarios = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = MostrarUsuarios.MostrarUsuarios();
                dvgUsuarios.DataSource = Conjunto.Tables["Usuarios"];
                dvgUsuarios.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string Busqueda;
            try
            {
                var BusquedaUsuario = new ServicioWeb.ServicioWebEscuela();
                Busqueda = txtBUsuario.Text;
                var conjunto = new DataSet();
                conjunto = BusquedaUsuario.BuscarrUsuarios(Busqueda);
                dvgUsuarios.DataSource = conjunto.Tables["Usuarios"];
                dvgUsuarios.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text="Error al consultar dato";
            }
        }

        protected void btnAlumnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlAlumnos.aspx");
        }

        protected void BtnPadres_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlUsuarios.aspx");
        }

        protected void btnSintomas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlSintomas.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }
    }
}