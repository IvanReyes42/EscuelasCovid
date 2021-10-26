<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlUsuarios.aspx.cs" Inherits="ControlEscuela.ControlUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style4 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="auto-style2">
            <table class="auto-style1">
                <tr>
                    <td>
                        <h1>Control de Sistemas Covid Escuelas</h1>
                    </td>
                    <td>
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Button ID="btnAlumnos" runat="server" Text="Alumnos"  Width="235px" OnClick="btnAlumnos_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="BtnPadres" runat="server" Text="Padres de Familia"  Width="235px" OnClick="BtnPadres_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSintomas" runat="server" Text="Registros Diarios"  Width="235px" OnClick="btnSintomas_Click" />
                    </td>
                </tr>
            </table>
            <br />
            Control Usuarios</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Nuevo Usuario</td>
                <td>Registros de usuarios</td>
            </tr>
            <tr>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Apellido Paterno</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txtAP" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Apellido Materno</td>
                            <td>
                                <asp:TextBox ID="txtAM" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Usuario</td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Contraseña</td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <table class="auto-style1">
                                    <tr>
                                        <td>Usuario</td>
                                        <td>
                                            <asp:TextBox ID="txtBUsuario" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
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
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
