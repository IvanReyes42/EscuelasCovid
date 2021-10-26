﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlEscuela
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgPortada.ImageUrl = "https://www.fda.gov/files/Final%20art%20031921_SPANISH.png";
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
    }
}