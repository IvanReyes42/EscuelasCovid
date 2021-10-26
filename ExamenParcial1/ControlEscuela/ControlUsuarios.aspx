<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="ControlUsuarios.aspx.cs" Inherits="ControlEscuela.ControlUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous" />

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style4 {
            height: 29px;
        }
        .btn
        {
            background-color: #5D7B9D;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h1>Control de Sistemas Covid Escuelas</h1>
        </div>

        <div class="container" >
          <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #5D7B9D;">
            <a class="navbar-brand" href="/MenuPrincipal.aspx" style="color:white;">Inicio</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
                  <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                      <li class="nav-item active">
                        <a class="nav-link" href="/ControlAlumnos.aspx" style="color:white;">Alumnos</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="/ControlUsuarios.aspx" style="color:white;">Padres de Familia</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="/ControlSintomas.aspx" style="color:white;">Sintomas</a>
                      </li>
                    </ul>
                  </div>
           </nav>
        </div>
        <br />
        <br />
        <div class="auto-style2">
            <h2>Control de Usuarios</h2> 
        </div>

        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-12">
                <h4>Nuevo Usuario</h4>
                  <div class="form-group">
                    <label for="">Nombre</label>
                    <asp:textbox type="text" class="form-control" ID="txtNombre" runat="server"></asp:textbox>
                  </div>
                  <div class="form-group">
                    <label for="">Apellido Paterno</label>
                    <asp:textbox type="text" class="form-control" ID="txtAP" runat="server"></asp:textbox>
                  </div>
                    <div class="form-group">
                    <label for="">Apellido Materno</label>
                    <asp:textbox type="text" class="form-control" ID="txtAM" runat="server"></asp:textbox>
                  </div>
                    <div class="form-group">
                    <label for="">Usuario</label>
                    <asp:textbox type="text" class="form-control" ID="txtUser" runat="server"></asp:textbox>
                  </div>
                    <div class="form-group">
                    <label for="">Contraseña</label>
                    <asp:textbox type="password" class="form-control" ID="txtPassword" runat="server"></asp:textbox>
                  </div>
                  
                    <div class="row">
                        <div class="col-lg-6 col-md-12">
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-6 col-md-12">
                            <asp:button type="button" class="btn btn-info" runat="server" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
            </div>

            <div class="col-lg-6 col-md-12">
                <h4>Registro de Usuarios</h4> 
                <div class="container">
                    <div class="input-group mb-5">
                        <asp:textbox type="text" class="form-control" placeholder="Usuario" aria-label="Usuario" aria-describedby="button-addon2" ID="txtBUsuario" runat="server"></asp:textbox>
                          <div class="input-group-append">
                            <asp:button class="btn btn-info" type="button" ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar" runat="server"/>
                          </div>
                    </div>
                    <div>
                        <asp:GridView ID="dvgUsuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="368px" HorizontalAlign="Center">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                    </div>
                </div>
            </div>
            </div>
        </div>



    </form>
</body>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-Piv4xVNRyMGpqkS2by6br4gNJ7DXjqk09RmUpJ8jgGtD7zP9yug3goQfGII0yAns" crossorigin="anonymous"></script>
</html>
