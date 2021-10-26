using ConexionEscuela;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlEscuela
{
    public partial class ControlAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string Matricula;
            var BuscarAlumno = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Matricula = txtMatricula.Text;
                Conjunto = BuscarAlumno.BuscarAlumnos(Matricula);
                dvgAlumnos.DataSource = Conjunto.Tables["Alumnos"];
                dvgAlumnos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Llenar()
        {
            var MostrarAlumnos = new ServicioWeb.ServicioWebEscuela();
            var Conjunto = new DataSet();
            try
            {
                Conjunto = MostrarAlumnos.MostrarAlumnos();
                dvgAlumnos.DataSource = Conjunto.Tables["Alumnos"];
                dvgAlumnos.DataBind();
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