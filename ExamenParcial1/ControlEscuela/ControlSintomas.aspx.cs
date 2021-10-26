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
    public partial class ControlSintomas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string Fecha, Sintomas, Asiste, Matricula;
            var MostrarSintomas = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Fecha = txtFecha.Text;
                //Sintomas = cmbSintomas.SelectedValue.ToString();
                //Asiste = cmbAsistenacia.SelectedValue.ToString();
                Matricula = txtMatricula.Text;
                
                Conjunto = MostrarSintomas.MostrarSintomas(Fecha, null, null, Matricula);
                dvgSintomas.DataSource = Conjunto.Tables["Sintomas"];
                dvgSintomas.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
            }
        }
        public void Llenar()
        {
            var MostrarSintomas = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = MostrarSintomas.MostrarSintomas(null,null,null,null);
                dvgSintomas.DataSource = Conjunto.Tables["Sintomas"];
                dvgSintomas.DataBind();
            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al mostrar Los datos";
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